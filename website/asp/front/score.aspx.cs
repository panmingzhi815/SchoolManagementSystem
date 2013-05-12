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

namespace Domain.asp.front
{
    public partial class score : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Student s = (Student)Session["user"];
            if (s != null) {
                ExamResultService ers = new ExamResultService();
                ers.getExamResultByStudent(s);
            }
        }
    }
}
