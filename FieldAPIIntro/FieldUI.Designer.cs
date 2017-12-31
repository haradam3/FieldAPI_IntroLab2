namespace FieldAPIIntro
{
    partial class FieldUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.labelUserName = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelRequest = new System.Windows.Forms.Label();
            this.labelResponse = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxRequest = new System.Windows.Forms.TextBox();
            this.textBoxResponse = new System.Windows.Forms.TextBox();
            this.buttonProject = new System.Windows.Forms.Button();
            this.labelProject = new System.Windows.Forms.Label();
            this.buttonIssue = new System.Windows.Forms.Button();
            this.labelIssue = new System.Windows.Forms.Label();
            this.buttonIssueCreate = new System.Windows.Forms.Button();
            this.labelNewIssue = new System.Windows.Forms.Label();
            this.textBoxNewIssue = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.comboBoxProjects = new System.Windows.Forms.ComboBox();
            this.comboBoxIssues = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Location = new System.Drawing.Point(20, 20);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(79, 17);
            this.labelUserName.TabIndex = 0;
            this.labelUserName.Text = "User Name";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(20, 50);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(69, 17);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Password";
            // 
            // labelRequest
            // 
            this.labelRequest.AutoSize = true;
            this.labelRequest.Location = new System.Drawing.Point(20, 190);
            this.labelRequest.Name = "labelRequest";
            this.labelRequest.Size = new System.Drawing.Size(61, 17);
            this.labelRequest.TabIndex = 2;
            this.labelRequest.Text = "Request";
            // 
            // labelResponse
            // 
            this.labelResponse.AutoSize = true;
            this.labelResponse.Location = new System.Drawing.Point(20, 290);
            this.labelResponse.Name = "labelResponse";
            this.labelResponse.Size = new System.Drawing.Size(72, 17);
            this.labelResponse.TabIndex = 3;
            this.labelResponse.Text = "Response";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(360, 20);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(90, 25);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(110, 20);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(230, 22);
            this.textBoxUserName.TabIndex = 5;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(110, 50);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(230, 22);
            this.textBoxPassword.TabIndex = 6;
            // 
            // textBoxRequest
            // 
            this.textBoxRequest.Location = new System.Drawing.Point(20, 210);
            this.textBoxRequest.Multiline = true;
            this.textBoxRequest.Name = "textBoxRequest";
            this.textBoxRequest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRequest.Size = new System.Drawing.Size(430, 70);
            this.textBoxRequest.TabIndex = 7;
            // 
            // textBoxResponse
            // 
            this.textBoxResponse.Location = new System.Drawing.Point(20, 310);
            this.textBoxResponse.Multiline = true;
            this.textBoxResponse.Name = "textBoxResponse";
            this.textBoxResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResponse.Size = new System.Drawing.Size(430, 110);
            this.textBoxResponse.TabIndex = 8;
            // 
            // buttonProject
            // 
            this.buttonProject.Location = new System.Drawing.Point(360, 90);
            this.buttonProject.Name = "buttonProject";
            this.buttonProject.Size = new System.Drawing.Size(90, 25);
            this.buttonProject.TabIndex = 9;
            this.buttonProject.Text = "Project";
            this.buttonProject.UseVisualStyleBackColor = true;
            this.buttonProject.Click += new System.EventHandler(this.buttonProject_Click);
            // 
            // labelProject
            // 
            this.labelProject.AutoSize = true;
            this.labelProject.Location = new System.Drawing.Point(20, 90);
            this.labelProject.Name = "labelProject";
            this.labelProject.Size = new System.Drawing.Size(52, 17);
            this.labelProject.TabIndex = 10;
            this.labelProject.Text = "Project";
            // 
            // buttonIssue
            // 
            this.buttonIssue.Location = new System.Drawing.Point(360, 130);
            this.buttonIssue.Name = "buttonIssue";
            this.buttonIssue.Size = new System.Drawing.Size(90, 25);
            this.buttonIssue.TabIndex = 11;
            this.buttonIssue.Text = "Issue";
            this.buttonIssue.UseVisualStyleBackColor = true;
            this.buttonIssue.Click += new System.EventHandler(this.buttonIssue_Click);
            // 
            // labelIssue
            // 
            this.labelIssue.AutoSize = true;
            this.labelIssue.Location = new System.Drawing.Point(20, 130);
            this.labelIssue.Name = "labelIssue";
            this.labelIssue.Size = new System.Drawing.Size(41, 17);
            this.labelIssue.TabIndex = 13;
            this.labelIssue.Text = "Issue";
            // 
            // buttonIssueCreate
            // 
            this.buttonIssueCreate.Location = new System.Drawing.Point(360, 160);
            this.buttonIssueCreate.Name = "buttonIssueCreate";
            this.buttonIssueCreate.Size = new System.Drawing.Size(90, 25);
            this.buttonIssueCreate.TabIndex = 15;
            this.buttonIssueCreate.Text = "Create";
            this.buttonIssueCreate.UseVisualStyleBackColor = true;
            this.buttonIssueCreate.Click += new System.EventHandler(this.buttonIssueCreate_Click);
            // 
            // labelNewIssue
            // 
            this.labelNewIssue.AutoSize = true;
            this.labelNewIssue.Location = new System.Drawing.Point(20, 160);
            this.labelNewIssue.Name = "labelNewIssue";
            this.labelNewIssue.Size = new System.Drawing.Size(72, 17);
            this.labelNewIssue.TabIndex = 16;
            this.labelNewIssue.Text = "New issue";
            // 
            // textBoxNewIssue
            // 
            this.textBoxNewIssue.Location = new System.Drawing.Point(110, 160);
            this.textBoxNewIssue.Name = "textBoxNewIssue";
            this.textBoxNewIssue.Size = new System.Drawing.Size(230, 22);
            this.textBoxNewIssue.TabIndex = 17;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(20, 460);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            series3.IsVisibleInLegend = false;
            series3.LabelAngle = 45;
            series3.Legend = "Legend1";
            series3.Name = "Issues\\nby status";
            series3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(430, 240);
            this.chart1.TabIndex = 18;
            this.chart1.Text = "chart1";
            title3.Name = "Title1";
            this.chart1.Titles.Add(title3);
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(360, 430);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(90, 25);
            this.buttonReport.TabIndex = 19;
            this.buttonReport.Text = "Report";
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Enabled = false;
            this.buttonLogout.Location = new System.Drawing.Point(360, 50);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(90, 25);
            this.buttonLogout.TabIndex = 20;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(117, 290);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 17);
            this.labelStatus.TabIndex = 21;
            // 
            // comboBoxProjects
            // 
            this.comboBoxProjects.FormattingEnabled = true;
            this.comboBoxProjects.Location = new System.Drawing.Point(110, 90);
            this.comboBoxProjects.Name = "comboBoxProjects";
            this.comboBoxProjects.Size = new System.Drawing.Size(230, 24);
            this.comboBoxProjects.TabIndex = 22;
            this.comboBoxProjects.SelectedIndexChanged += new System.EventHandler(this.comboBoxProject_SelectedIndexChanged);
            // 
            // comboBoxIssues
            // 
            this.comboBoxIssues.FormattingEnabled = true;
            this.comboBoxIssues.Location = new System.Drawing.Point(110, 130);
            this.comboBoxIssues.Name = "comboBoxIssues";
            this.comboBoxIssues.Size = new System.Drawing.Size(230, 24);
            this.comboBoxIssues.TabIndex = 23;
            this.comboBoxIssues.SelectedIndexChanged += new System.EventHandler(this.comboBoxIssues_SelectedIndexChanged);
            // 
            // FieldUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 725);
            this.Controls.Add(this.comboBoxIssues);
            this.Controls.Add(this.comboBoxProjects);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.textBoxNewIssue);
            this.Controls.Add(this.labelNewIssue);
            this.Controls.Add(this.buttonIssueCreate);
            this.Controls.Add(this.labelIssue);
            this.Controls.Add(this.buttonIssue);
            this.Controls.Add(this.labelProject);
            this.Controls.Add(this.buttonProject);
            this.Controls.Add(this.textBoxResponse);
            this.Controls.Add(this.textBoxRequest);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.labelResponse);
            this.Controls.Add(this.labelRequest);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUserName);
            this.Name = "FieldUI";
            this.Text = "Field API Intro";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FieldUI_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelRequest;
        private System.Windows.Forms.Label labelResponse;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxRequest;
        private System.Windows.Forms.TextBox textBoxResponse;
        private System.Windows.Forms.Button buttonProject;
        private System.Windows.Forms.Label labelProject;
        private System.Windows.Forms.Button buttonIssue;
        private System.Windows.Forms.Label labelIssue;
        private System.Windows.Forms.Button buttonIssueCreate;
        private System.Windows.Forms.Label labelNewIssue;
        private System.Windows.Forms.TextBox textBoxNewIssue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox comboBoxProjects;
        private System.Windows.Forms.ComboBox comboBoxIssues;
    }
}

