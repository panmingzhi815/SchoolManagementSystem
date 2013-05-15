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
using DataService.service.dao;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Student s = (Student)Session["user"];
            if (s != null) {
                welcomeInfo.InnerHtml = "欢迎你," + s.Name;
            }
            DepartmentService ds = new DepartmentService();

            IList<School> schoolList =  ds.getSchoolList();
            if (schoolList != null && schoolList.Count > 0)
            {
                SchoolContent.InnerHtml = "<h1>" + schoolList[0].Name + "</h1>" + "<p class='lead'>" + schoolList[0].SimpleDescript + "</p>";
            }

            IList<Faculty> facultyList = ds.getFacultyList();
            string content1 = "";
            string content2 = "";
            for (int i = 0; i < facultyList.Count; i++) { 
               Faculty faculty = facultyList[i];
               if (i < 3) {
                   content1 += "<h4>" + faculty.Name + "</h4>";
                   content1 += "<p>" + faculty.SimpleDescript + "</p>";
               }
               else if (i > 2 && i < 6) {
                   content2 += "<h4>" + faculty.Name + "</h4>";
                   content2 += "<p>" + faculty.SimpleDescript + "</p>";
               }
            }
            FacultyColumn1.InnerHtml = content1;
            FacultyColumn2.InnerHtml = content2;
        }
    }
}
