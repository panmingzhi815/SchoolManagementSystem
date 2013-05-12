using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Domain.Entities;
using DataService.service.dao;
using System.Collections.Generic;

namespace Domain.asp.front
{
    public partial class score : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Student s = (Student)Session["user"];
            if (s != null) {
                ExamResultService ers = new ExamResultService();
                IList<ExamResult> examResultList = ers.getExamResultByStudent(s);
                string content = "";
                foreach (ExamResult er in examResultList) {
                    content += "<h4>" + er.ExamPlan.Name + "</h4>";
                    IDictionary<string,string> couresScoureMap = er.CouresScoreMap;
                    string[] keys = new string[couresScoureMap.Keys.Count];
                    content += "<table class='table table-striped table-bordered table-condensed'><thead><tr>";
                    for (int i = 0; i < keys.Length; i++) {
                        String key = couresScoureMap.Keys.ElementAt(i);
                        keys[i] = key;
                        content += "<th>" + key + "</th>";
                    }
                    content += "</tr></thead><tbody><tr>";
                    for (int i = 0; i < keys.Length; i++)
                    {
                        String key = keys[i];
                        content += "<td>" + couresScoureMap[key] + "</td>";
                    }
                    content += "</tr></tbody></table>";
                }
                TableContent.InnerHtml = content;
            }
        }
    }
}
