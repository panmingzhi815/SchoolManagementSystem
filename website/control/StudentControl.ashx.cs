using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Reflection;
using Domain.Entities;
using DataService.service.dao;
using DataService.util;

namespace Domain.control
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class StudentControl : IHttpHandler
    {
        public HttpContext context;
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            context.Response.ContentType = "text/plain";
            String method = context.Request.QueryString["method"];
            switch (method)
            {
                case "addStudent":
                    addStudent();
                    break;
                default:
                    context.Response.Write("-1");
                    break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void addStudent()
        {
            Student student = new Student();
            setValue(student, context);

            HttpPostedFile hpf = context.Request.Files["headImgFile"];
            string savepath = context.Server.MapPath("/uploadFile/headImg/" + student.Id + "." + hpf.GetType());//路径,相对于服务器当前的路径
            hpf.SaveAs(savepath);//保存

            student.HeadImage = savepath;
            StudentService s = new StudentService();
            s.add(student);

            context.Response.Write("1");

        }

        public Object setValue(Object o, HttpContext context)
        {
            string[] keys = context.Request.Form.AllKeys;
            foreach (string s in keys)
            {
                try
                {
                    PropertyInfo property = o.GetType().GetProperty(s);
                    if (property != null)
                        property.SetValue(o, context.Request.Form.Get(s), null);
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }

            }
            return o;
        }

    }
}
