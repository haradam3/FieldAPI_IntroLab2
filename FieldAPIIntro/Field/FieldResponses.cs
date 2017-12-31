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

namespace FieldAPIIntro
{
    [Serializable] 
    public class LoginResponse
    {
        public string ticket { get; set; }
        public string message { get; set; }
        public string title { get; set; }
    }

    [Serializable]
    public class Project
    {
        public string id { get; set; }
        public string name { get; set; }
        //public string a360_project_id { get; set; }
        public string updated_at { get; set; }
    }

    [Serializable]
    public class Issue
    {
        public string id { get; set; }
        public string created_by { get; set; }
        //public string fields { get; set; }
        //public IssueFieldItem[] fields { get; set; } 
        public List<IssueFieldItem> fields { get; set; }
        public List<Object> comments { get; set; }
        public List<Object> attachments { get; set; }
    }

    [Serializable]
    public class IssueFieldItem
    {
        public string id { get; set; }
        public string name { get; set; }
        public string display_type { get; set; }
        public string value { get; set; }
    }

    [Serializable]
    public class IssueCreateResponse 
    {
        public bool success { get; set; }
        public List<object> general_errors { get; set; }
        public List<object> errors { get; set; }
        public string id { get; set; }
        public string temporary_id { get; set; }
    }

}
