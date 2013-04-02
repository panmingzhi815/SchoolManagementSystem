using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Web.SessionState;

namespace Domain.control
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class UserControl : IHttpHandler, IRequiresSessionState
    {
        public HttpContext context;
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            context.Response.ContentType = "text/plain";
            string method = context.Request.QueryString.Get("method");
            switch (method) {
                case "createUser":
                    createUser();
                    break;
                case "updateUser":
                    updateUser();
                    break;
                case "deleteUser":
                    deleteUser();
                    break;
                case "login" :
                    login();
                    break;
                default :
                    context.Response.Write("-1");
                    return;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void createUser()
        { 
            
        }

        public void updateUser()
        { 
        
        }

        public void deleteUser()
        { 
        
        }

        public void login()
        {
            string username = context.Request.QueryString.Get("username");
            string password = context.Request.QueryString.Get("password");
            if (username == "admin" && password == "admin")
            {

                context.Session.Add("username", username);
                context.Session.Add("password", password);
                context.Response.Write("1");
            }
            else {
                context.Response.Write("0");
            }
        }

    }
}
