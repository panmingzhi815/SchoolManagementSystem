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
using Domain.Entities;

namespace Domain.asp.front
{
    public partial class info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Student s = (Student)Session["user"];
            if (s != null)
            {
                Sn.Value = s.Sn;
                Name.Value = s.Name;
                IDCode.Value = s.IDcode;
                Nation.Value = s.Nation;
                Address.Value = s.Address;
                MobilePhone.Value = s.MobilePhone;
                Telphone.Value = s.Telphone;
                Password.Value = s.Password;
                welcomeInfo.InnerHtml = "欢迎你," + s.Name;
            }
            else {
                Response.Redirect("login.aspx");
            }
        }
    }
}
