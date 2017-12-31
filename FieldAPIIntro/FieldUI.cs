#region Copyright
//
// Copyright (C) 2015-2017 by Autodesk, Inc.
//
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted,
// provided that the above copyright notice appears in all copies and
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS.
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC.
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
//
// Use, duplication, or disclosure by the U.S. Government is subject to
// restrictions set forth in FAR 52.227-19 (Commercial Computer
// Software - Restricted Rights) and DFAR 252.227-7013(c)(1)(ii)
// (Rights in Technical Data and Computer Software), as applicable.
//
// Written by M.Harada
// 
#endregion // Copyright

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Added for RestSharp. 
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers; 

namespace FieldAPIIntro
{
    public partial class FieldUI : Form
    {
        // Save info needed. 
        private static string m_ticket = "";
        private static List<Project> m_proj_list;
        private static List<Issue> m_issue_list; 

        //====================================================================
        // Form Start/End 
        //====================================================================
        public FieldUI()
        {
            InitializeComponent();
        }

        private void FieldUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_ticket != "")
            {
                bool result = Field.Logout(m_ticket);
            }
        }

        //=========================================================
        //  Login/Logout 
        //=========================================================
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Get the user name and password from the user. 
            string userName = textBoxUserName.Text;
            string password = textBoxPassword.Text;

            InitRequestResponse(); 
            this.Update();

            // Here is the main part that we call Field API login 
            m_ticket = Field.Login(userName, password);

            // If success, change the button to logout.
            if (m_ticket != null && m_ticket.Length > 0)
            {
                buttonLogin.Enabled = false;
                buttonLogout.Enabled = true;
            }

            // For our learning, 
            // show the request and response in the form. 
            ShowRequestResponse(); 
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            InitRequestResponse();
            this.Update();

            // Here is the main call to Field API. 
            bool result = Field.Logout(m_ticket);

            m_ticket = "";
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;

            // For our learning, 
            // show the request and response in the form. 
            ShowRequestResponse();
        }

        //==========================================================
        // Helper functions 
        //==========================================================
        private void InitRequestResponse()
        {
            // initialize the request and response text in the form.
            textBoxRequest.Text = "Request comes here";
            labelStatus.Text = "";
            textBoxResponse.Text = "Response comes here. This may take seconds. Please wait...";
        }
        private void ShowRequestResponse()
        {
            // show the request and response in the form. 
            IRestResponse response = Field.m_lastResponse;
            textBoxRequest.Text = response.ResponseUri.AbsoluteUri;
            labelStatus.Text = "Status: " + response.StatusCode.ToString();
            textBoxResponse.Text = response.Content;
        }

        //=========================================================
        //  Projects
        //=========================================================
        private void buttonProject_Click(object sender, EventArgs e)
        {
            InitRequestResponse();
            this.Update();

            m_proj_list = Field.ProjectNames(m_ticket);

            ShowRequestResponse();

            if (m_proj_list == null)
            {
                return;
            }

            // Set up a project list
            m_proj_list = m_proj_list.OrderBy(x => x.name).ToList(); 
            comboBoxProjects.DataSource = new BindingSource(m_proj_list, null);
            comboBoxProjects.DisplayMember = "name";
            comboBoxProjects.ValueMember = "id";
            comboBoxProjects.SelectedIndex = 0; 
        }

        private void comboBoxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            // clear issues (TBD) 
            comboBoxIssues.Items.Clear();
            textBoxNewIssue.Clear(); 
        }

        //=========================================================
        //  Issues Retrieve 
        //=========================================================
        private void buttonIssue_Click(object sender, EventArgs e)
        {
            InitRequestResponse();
            this.Update();

            Project proj = (Project)comboBoxProjects.SelectedItem;
            string project_id = proj.id; 
            string area_ids = "No Area"; // MH: ignore for this exercise. 

            m_issue_list = Field.IssueList(m_ticket, project_id, area_ids);

            ShowRequestResponse();

            // Post process to make a list of issues of form:  
            // "issue-id : { issue string }"  

            // To convert an issue back to a JSON tring 
            JsonSerializer serial = new JsonSerializer();            

            // Make an issue list in a string and add to a combobox. 
            comboBoxIssues.Items.Clear(); 
            foreach(Issue issue in m_issue_list)
            {
                IssueFieldItem issueId = issue.fields.Find(x => x.name.Equals("Identifier"));
                string s = issueId.value + " : " + serial.Serialize(issue); 
                comboBoxIssues.Items.Add(s);
            }
            comboBoxIssues.SelectedIndex = 0;

            // Make one issue for creation. This is for later use.  
            Issue tmpIssue = m_issue_list[0];
            textBoxNewIssue.Text = MakeTemporaryIssueString(tmpIssue);
        }

        private void comboBoxIssues_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set a new temporary issue string based on the selected one. 
            Issue tmpIssue = m_issue_list[comboBoxIssues.SelectedIndex];
            textBoxNewIssue.Text = MakeTemporaryIssueString(tmpIssue);
        }

        /// Helper to make a temporary issue string for an issue creation. 
        /// 
        /// Given an issue data, compose a string like below.
        /// This is for creating an issue. 
        /// 
        /// [{
        ///     "temporary_id":"Q45", 
        ///     "fields": [
        ///        {"id":"f--description","value":"Test"}, 
        ///        {"id":"f--issue_type_id", "value":"f498d0f5-0be0-11e2-9694-14f6960d7e4f"} 
        ///     ]
        /// }]
        /// 
        private string MakeTemporaryIssueString(Issue issue)
        {
            string issueString = null;

            // Compose the JSON data with fields values 
            foreach (IssueFieldItem item in issue.fields)
            {
                if (item.value == null) continue;
                if (item.id.Equals("f--identifier")) continue; 
                
                string s = "{\"id\":\"" + item.id + "\","
                    + "\"value\":\"" + item.value.ToString() + "\"},";
                issueString += s;
                
            }
            int len = issueString.Length; 
            if (len > 0)
            {
                // removing the last extra ',' 
                issueString = issueString.Remove(len - 1); 
            }
            // This is the whole string 
            issueString = "[{\"temporary_id\":\"Tmp001\",\"fields\":["
                + issueString + "]}]"; 

            return issueString;  
        }

        //=========================================================
        //  Issue Create 
        //=========================================================
        private void buttonIssueCreate_Click(object sender, EventArgs e)
        {
            InitRequestResponse();
            this.Update();

            Project proj = (Project)comboBoxProjects.SelectedItem;
            string project_id = proj.id;

            // e.g.,  
            // [{
            //     "temporary_id":"Q45", 
            //     "fields": [
            //        {"id":"f--description","value":"Test"}, 
            //        {"id":"f--issue_type_id", "value":"f498d0f5-0be0-11e2-9694-14f6960d7e4f"} 
            //     ]
            // }]

            // e.g., 
            //string issues = "[{\"temporary_id\":\"Q45\",\"fields\":[{\"id\":\"f--description\",\"value\":\"This is a test\"}]}]";  
            string newIssue = textBoxNewIssue.Text; 

            // e.g., This works 
            //string issues = "[{\"temporary_id\":\"Q45\",\"fields\":[{\"id\":\"f--description\",\"value\":\"This is a test\"},{\"id\":\"f--issue_type_id\",\"value\":\"f498d0f5-0be0-11e2-9694-14f6960d7e4f\"}]}]";  

            // Here is the main Filed API call. 
            string issue_id = Field.IssueCreate(m_ticket, project_id, newIssue);

            ShowRequestResponse();
        }

        //============================================================
        // Report
        // Make a chart showing the numbers of issues by status.
        // This is not a part of Field API. 
        // Just to show what you can do with the retrieved data.
        //============================================================
        private void buttonReport_Click(object sender, EventArgs e)
        {
            // Collect data from the issue list.
            // Count the number of issues for each status. 
            Dictionary<string, int> data = new Dictionary<string,int>();  

            foreach(Issue issue in m_issue_list) {
                string status = issue.fields.Find(x => x.name.Equals("Status")).value; 
                if(data.ContainsKey(status)) {
                    data[status]++;
                }
                else {
                    data.Add(status, 1); 
                }

            }

            // Clear the chart data 
            chart1.Series[0].Points.Clear(); 

            // Fill the chart data  
            foreach (var item in data)
            {
                chart1.Series[0].Points.AddXY(item.Key, item.Value); 
            }

            // Add a title text 
            chart1.Titles[0].Text = "Issues by Status"; 
        }

    } // class FieldUI 

} // namespace FieldAPIIntro
