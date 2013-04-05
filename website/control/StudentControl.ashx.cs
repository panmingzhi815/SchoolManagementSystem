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
using Newtonsoft.Json;
using System.Web.Script.Serialization;

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
            String method = context.Request.Form.Get("method");
            if (method == null)
            {
                method = context.Request.QueryString["method"];
            }
            switch (method)
            {
                case "addStudent":
                    addStudent();
                    break;
                case "delStudent":
                    delStudent();
                    break;
                case "updateStudent":
                    updateStudent();
                    break;
                case "getStudents":
                    getStudents();
                    break;
                case "getStudent":
                    getStudent();
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
            try
            {
                Student student = new Student();
                setValue(student, context);

                HttpPostedFile hpf = context.Request.Files["headImgFile"];
                if (hpf != null)
                {
                    string savepath = context.Server.MapPath("/uploadFile/headImg/" + student.Id + "." + hpf.GetType());//路径,相对于服务器当前的路径
                    hpf.SaveAs(savepath);//保存
                    student.HeadImage = savepath;
                }
               
                StudentService s = new StudentService();
                s.add(student);
                context.Response.Write("1");
            }
            catch (Exception e)
            {
                context.Response.Write("0");
            }
        }

        public void delStudent()
        {
            try
            {
                string Id = context.Request.QueryString["Id"];
                StudentService service = new StudentService();
                service.del(service.get(typeof(Student), Id));
                context.Response.Write("1");
            }
            catch (Exception e)
            {
                context.Response.Write("0");
            }

        }

        public void updateStudent()
        {
            try
            {
                Student student = new Student();
                setValue(student, context);

                HttpPostedFile hpf = context.Request.Files["headImgFile"];
                if (hpf != null) {
                    string savepath = context.Server.MapPath("/uploadFile/headImg/" + student.Id + "." + hpf.GetType());//路径,相对于服务器当前的路径
                    hpf.SaveAs(savepath);//保存
                    student.HeadImage = savepath;
                }
                
                StudentService s = new StudentService();
                s.updata(student);
                context.Response.Write("1");
            }
            catch (Exception e)
            {
                context.Response.Write("0");
            }
        }

        public void getStudent() {
            string Id = context.Request.QueryString["Id"];
            StudentService service = new StudentService();
            Student student = (Student)service.get(typeof(Student), Id);
            String json = JsonConvert.SerializeObject(student);
            context.Response.Write(json);
        }

        public void getStudents()
        {
            try
            {
                StudentService service = new StudentService();
                Student student = new Student();
                int rows = Convert.ToInt32(context.Request.Form["rows"]);
                int page = Convert.ToInt32(context.Request.Form["page"]);
                object[] data = service.getStudentList(student, rows, page);
                Hashtable ht = new Hashtable();
                ht.Add("total", data[0]);
                ht.Add("rows", data[1]);
                String json = JsonConvert.SerializeObject(ht);
                context.Response.Write(json);
            }
            catch (Exception e)
            {

            }

        }

        public Object setValue(Object o, HttpContext context)
        {
            string[] keys = context.Request.Form.AllKeys;
            foreach (string s in keys)
            {
                try
                {
                    PropertyInfo property = o.GetType().GetProperty(s);
                    if (property == null)
                    {
                        continue;
                    }
                    if (property.PropertyType == typeof(DateTime))
                    {
                        property.SetValue(o, Convert.ToDateTime(context.Request.Form.Get(s)), null);
                    }
                    else if (property.PropertyType == typeof(string) || property.PropertyType == typeof(int))
                    {
                        property.SetValue(o, context.Request.Form.Get(s), null);
                    }

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
