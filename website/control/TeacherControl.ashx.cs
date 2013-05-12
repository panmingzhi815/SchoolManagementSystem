using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using DataService.service.dao;
using Domain.Entities;
using Newtonsoft.Json;
using System.Reflection;

namespace Domain.control
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class TeacherControl : IHttpHandler
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
                case "addTeacher":
                    addTeacher();
                    break;
                case "delTeacher":
                    delTeacher();
                    break;
                case "updateTeacher":
                    updateTeacher();
                    break;
                case "getTeachers":
                    getTeachers();
                    break;
                case "getTeacher":
                    getTeacher();
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
        public void addTeacher()
        {
            try
            {
                Teacher Teacher = new Teacher();
                setValue(Teacher, context);

                HttpPostedFile hpf = context.Request.Files["headImgFile"];
                if (hpf != null)
                {
                    string serverPath = "/uploadFile/headImg/" + System.DateTime.Now.Ticks + "." + hpf.FileName.Split('.')[1];
                    string savePath = context.Server.MapPath(serverPath);//路径,相对于服务器当前的路径
                    hpf.SaveAs(savePath);//保存
                    Teacher.HeadImage = serverPath;
                }

                TeacherService s = new TeacherService();
                s.save(Teacher);

                context.Response.Write("1");
            }
            catch (Exception e)
            {
                context.Response.Write("0");
            }
        }

        public void delTeacher()
        {
            try
            {
                string Id = context.Request.QueryString["Id"];
                TeacherService service = new TeacherService();
                service.del(service.get(typeof(Teacher), Id));
                context.Response.Write("1");
            }
            catch (Exception e)
            {
                context.Response.Write("0");
            }

        }

        public void updateTeacher()
        {
            try
            {
                Teacher Teacher = new Teacher();
                setValue(Teacher, context);

                HttpPostedFile hpf = context.Request.Files["headImgFile"];
                if (hpf != null)
                {
                    string savepath = context.Server.MapPath("/uploadFile/headImg/" + Teacher.Id + "." + hpf.GetType());//路径,相对于服务器当前的路径
                    hpf.SaveAs(savepath);//保存
                    Teacher.HeadImage = savepath;
                }

                TeacherService s = new TeacherService();
                s.save(Teacher);
                context.Response.Write("1");
            }
            catch (Exception e)
            {
                context.Response.Write("0");
            }
        }

        public void getTeacher()
        {
            string Id = context.Request.QueryString["Id"];
            TeacherService service = new TeacherService();
            Teacher Teacher = (Teacher)service.get(typeof(Teacher), Id);
            String json = JsonConvert.SerializeObject(Teacher);
            context.Response.Write(json);
        }

        public void getTeachers()
        {
            try
            {
                TeacherService service = new TeacherService();
                Teacher Teacher = new Teacher();
                setValue(Teacher, context);

                int rows = Convert.ToInt32(context.Request.Form["rows"]);
                int page = Convert.ToInt32(context.Request.Form["page"]);
                object[] data = service.getTeacherList(Teacher, rows, page);
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
