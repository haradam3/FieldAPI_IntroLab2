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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net; // for HttpStatusCode 
// Added for RestSharp 
using RestSharp;
using RestSharp.Deserializers;  

namespace FieldAPIIntro
{
    class Field
    {
        // Constants 
        private const string _baseUrl = @"https://bim360field.autodesk.com";

        // Member variables 
        // Save the last response. This is for learning purpose. 
        public static IRestResponse m_lastResponse = null;

        ///===================================================
        /// Login
        /// URL:  
        /// https://bim360field.autodesk.com/api/login
        /// Method: POST
        /// Description: 
        /// Authenticate using BIM 360 Field credentials. 
        /// On success, returns a 36 byte GUID "ticket" which 
        /// needs to be passed in on subsequent calls.
        /// Doc: 
        /// https://bim360field.autodesk.com/apidoc/index.html#mobile_api_method_1
        /// 
        /// Sample Response (JSON) 
        /// {"ticket":"0054444d-be79-1345-6657-45422efd9d80","message":"","title":""}
        /// 
        ///===================================================
        public static string Login(string userName, string password)
        {
            // (1) Build request 
            var client = new RestClient();
            client.BaseUrl = new System.Uri(_baseUrl);

            // Set resource/end point 
            var request = new RestRequest();
            request.Resource = "/api/login";
            request.Method = Method.POST;

            // Set required parameters 
            request.AddParameter("username", userName);
            request.AddParameter("password", password);

            Debug.WriteLine("Calling POST /api/login ...");

            // (2) Execute request and get response
            IRestResponse response = client.Execute(request);

            // Save response. This is to see the response for our learning.
            m_lastResponse = response;

            Debug.WriteLine("StatusCode = " + response.StatusCode);

            // (3) Parse the response and get the ticket. 
            string ticket = "";
            if (response.StatusCode == HttpStatusCode.OK)
            {
                JsonDeserializer deserial = new JsonDeserializer();
                LoginResponse loginResponse = 
                    deserial.Deserialize<LoginResponse>(response);
                ticket = loginResponse.ticket; 
            }

            return ticket; 
        }

        ///===================================================
        /// Logout
        /// URL:  
        /// https://bim360field.autodesk.com/api/logout
        /// Method: POST
        /// Description: 
        /// Closes the current active session by expiring the ticket. 
        /// Doc:
        /// https://bim360field.autodesk.com/apidoc/index.html#mobile_api_method_2
        /// 
        /// No response body.
        /// Note: there is a second parameter asking for project_id.
        /// But it works without it. 
        /// 
        ///===================================================
        public static bool Logout(string ticket)
        {
            // (1) Build request 
            var client = new RestClient();
            client.BaseUrl = new System.Uri(_baseUrl);

            // Set resource/end point 
            var request = new RestRequest();
            request.Resource = "/api/logout";
            request.Method = Method.POST;

            // Set required parameters 
            request.AddParameter("ticket", ticket);

            Debug.WriteLine("Calling POST /api/logout ...");

            // (2) Execute request and get response
            IRestResponse response = client.Execute(request);

            // Save response. This is to see the response for our learning.
            m_lastResponse = response;

            Debug.WriteLine("StatusCode = " + response.StatusCode);

            // (3) Parse the response and get the ticket. 
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        ///==================================================
        /// <summary>
        /// /fieldapi/admin/v1/project_names
        /// Get a list of project names  
        /// URL:  
        /// https://bim360field.autodesk.com/fieldapi/admin/v1/project_names
        /// Method: POST
        /// Description: 
        /// Get a list of project names and project identifiers  
        /// that are asscociated with the account.
        /// Doc:
        /// https://bim360field.autodesk.com/apidoc/index.html#admin_api_method_3
        /// 
        /// Sample Response (JSON)
        /// [
        ///   {"id" : "12345678-12312-12313-1231312","name" : "Sonoma House","a360_project_id" : null,"updated_at" : "2013-07-10T12:30:10Z"},
        ///   {"id" : "67236712-23112-87777-9999991","name" : Zip Energy Center - Cx","a360_project_id" : "ABC123GHI","updated_at" : "2013-07-10T12:30:10Z"}
        /// ]
        ///
        /// </summary>
        /// <returns></returns>
        /// =================================================
        public static List<Project> ProjectNames(string ticket)
        {
            // (1) Build request 
            var client = new RestClient();
            client.BaseUrl = new System.Uri(_baseUrl);

            // Set resource or end point 
            var request = new RestRequest();
            request.Resource = "/fieldapi/admin/v1/project_names";
            request.Method = Method.POST;

            // Add parameters 
            request.AddParameter("ticket", ticket);

            Debug.WriteLine("Calling POST /fieldapi/admin/v1/project_names ...");

            // (2) Execute request and get response
            IRestResponse response = client.Execute(request);

            // Save response. This is to see the response for our learning.
            m_lastResponse = response;

            Debug.WriteLine("StatusCode = " + response.StatusCode);

            // (3) Parse the response and get the list of projects. 

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null; 
            }

            JsonDeserializer deserial = new JsonDeserializer();
            List<Project> proj_list = deserial.Deserialize<List<Project>>(response);

            return proj_list;
        }

        ///==================================================
        /// <summary>
        /// POST /fieldapi/issues/v1/list
        /// Get a list of issues   
        /// URL:  
        /// https://bim360field.autodesk.com/fieldapi/issues/v1/list
        /// Method: POST
        /// Description: 
        /// Get a list of issues in the given project.
        /// Note 1: there is another method, "/api/get_issues". 
        /// /fieldapi/ is prefered over /api/ where available.
        /// Note 2: parameter offset and limit aren't functioning 
        /// as the online help document states. 
        /// Doc:         
        /// https://bim360field.autodesk.com/apidoc/index.html#issues_api_method_10  
        ///
        /// </summary>
        /// <returns></returns>
        /// =================================================
        public static List<Issue> IssueList(string ticket, string project_id, string area_ids, int offset=0, int limit=25)
        {
            // (1) Build request 
            var client = new RestClient();
            client.BaseUrl = new System.Uri(_baseUrl);

            // Set resource or end point 
            var request = new RestRequest();
            request.Resource = "/fieldapi/issues/v1/list"; // /fieldapi/ is prefered over /api/
            //request.Resource = "/api/get_issues";
            request.Method = Method.POST;

            // Add parameters 
            request.AddParameter("ticket", ticket);
            request.AddParameter("project_id", project_id);
            //request.AddParameter("area_ids", area_ids); // MH: ignore for this exersize. 
            //request.AddParameter("offset", offset); // MH: Bug. Does not do anything.

            // limit - default is 25. 
            // uncomment this if you want to have a whole list 
            request.AddParameter("limit", limit); // MH: Bug. If you specify other than "", it returns the whole list.   

            Debug.WriteLine("Calling POST /fieldapi/issues/v1/list ...");

            // (2) Execute request and get response
            IRestResponse response = client.Execute(request);

            // Save response. This is to see the response for our learning.
            m_lastResponse = response;

            Debug.WriteLine("StatusCode = " + response.StatusCode);

            // (3) Parse the response and get the list of issues. 

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            JsonDeserializer deserial = new JsonDeserializer();
            List<Issue> issue_list = deserial.Deserialize<List<Issue>>(response);

            return issue_list;
        }

        ///==================================================
        /// <summary>
        /// /fieldapi/issues/v1/create
        /// Create a new issue.  
        /// URL:  
        /// https://bim360field.autodesk.com/fieldapi/issues/v1/create
        /// Method: POST
        /// Doc:         
        /// https://bim360field.autodesk.com/apidoc/index.html#issues_api_method_11  
        /// Description: 
        /// Create a new issue 
        /// The "fields" is an array of "field identifier and value" pair. 
        /// 
        /// Sample issues array:
        /// The following shows an array with one issue. 
        /// The issue is filling in the minimal fields of 
        /// the Issue Type Id and the Description: 
        /// [
        ///   {
        ///   "temporary_id":"Q45",
        ///   "fields": [
        ///     {"id":"f--description","value":"This is a test of creating an issue"},
        ///     {"id":"f--issue_type_id","value":"f475d0f5-0be0-11e2-4236-14f6960d7e4f"}
        ///     ],
        ///   "uri_references":[{"name":"Yahoo!","path":"http://www.yahoo.com"}]
        ///   }
        /// ]
        /// 
        /// </summary>
        /// <returns></returns>
        /// =================================================
        public static string IssueCreate(string ticket, string project_id, string issues)
        {
            // (1) Build request 
            var client = new RestClient();
            client.BaseUrl = new System.Uri(_baseUrl);

            // Set resource or end point 
            var request = new RestRequest();
            request.Resource = "/fieldapi/issues/v1/create"; // /fieldapi/ is prefered over /api/
            request.Method = Method.POST;

            // Add parameters 
            request.AddParameter("ticket", ticket);
            request.AddParameter("project_id", project_id);
            request.AddParameter("issues", issues);

            Debug.WriteLine("Calling POST /fieldapi/issues/v1/create ...");

            // (2) Execute request and get response
            IRestResponse response = client.Execute(request);

            // Save response. This is to see the response for our learning.
            m_lastResponse = response;

            Debug.WriteLine("StatusCode = " + response.StatusCode);

            // (3) Parse the response and get the list of issues create.   

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            JsonDeserializer deserial = new JsonDeserializer();
            List<IssueCreateResponse> issueCreateResponse = 
                deserial.Deserialize<List<IssueCreateResponse>>(response);
            
            return issueCreateResponse[0].id; // return the id of the first one for this exercise. 
        }

    }
}
