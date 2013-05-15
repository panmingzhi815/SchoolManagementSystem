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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            if (Sn.Value == "") {
                ErrorInfos.InnerHtml = "用户名不能为空";
                return;
            }
            else if (Password.Value == "") {
                ErrorInfos.InnerHtml = "密码不能为空";
                return;
            }
            StudentService ss = new StudentService();
            Student s = ss.login(Sn.Value, Password.Value);
            if (s == null)
            {
               ErrorInfos.InnerHtml = "用户名或密码错误";
            }
            else {
                Session["user"] = s;
                Response.Redirect("index.aspx");
            }
        }
    }
}
