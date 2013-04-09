using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

namespace Domain.control
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class DepartmentControl : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void getDepartmentList()
        {

        }

        public void getDepartment()
        {

        }

        public void addDepartment()
        {

        }

        public void updateDepartment()
        {

        }

        public void delDepartment()
        {

        }

        public void getPrefessionList()
        {

        }

        public void getPrefession()
        {

        }

        public void addPrefession()
        {

        }

        public void updatePrefession()
        {

        }

        public void delPrefession()
        {

        }
        public void getClassGradeList()
        {

        }

        public void addClassGrade()
        {

        }

        public void delClassGrade()
        {

        }
    }
}
