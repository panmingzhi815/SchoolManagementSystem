using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Reflection;
using DataService.service.dao;
using Domain.Entities;
using Iesi.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.control
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CouresControl : IHttpHandler
    {
        public HttpContext context;
        public void ProcessRequest(HttpContext context)
        {
            this.context = context;
            context.Response.ContentType = "text/plain";
            string method = context.Request.Form.Get("method");
            if (method == null)
            {
                method = context.Request.QueryString["method"];
            }
            switch (method)
            {
                case "getCouresByID":
                    getCouresByID();
                    break;
                case "searchCoures":
                    searchCoures();
                    break;
                case "saveCoures":
                    saveCoures();
                    break;
                case "deleteCoures":
                    deleteCoures();
                    break;
                default:
                    context.Response.Write("-1");
                    break;
            }
        }

        private void deleteCoures()
        {
            try
            {
                string CouresID = context.Request.Form.Get("CouresID");
                CouresService cs = new CouresService();
                cs.del(cs.getCouresByID(CouresID));
                context.Response.Write("1");
            }
            catch (Exception e)
            {
                context.Response.Write("0");
            }
        }

        private void saveCoures()
        {
            try
            {
                string professionID = context.Request.Form.Get("profession");
                DepartmentService ds = new DepartmentService();
                Profession profession = ds.getProfessionByID(professionID);
                if (profession != null)
                {
                    Coures c = new Coures();
                    setValue(c, context);
                    c.Profession = profession;
                    ds.save(c);
                    context.Response.Write("1");
                }
            }
            catch (Exception e) {
                context.Response.Write("0");
            }
        }

        private void searchCoures()
        {
            System.Collections.IList professionList = new ArrayList();
            string FacultyID = context.Request.Form.Get("FacultyID");
            string ProfessionID = context.Request.Form.Get("ProfessionID");
            string YearNo = context.Request.Form.Get("YearNo");
            string LevelNo = context.Request.Form.Get("LevelNo");
            if (!string.IsNullOrEmpty(ProfessionID)) {
                DepartmentService ds = new DepartmentService();
                Profession p = ds.getProfessionByID(ProfessionID);
                professionList.Add(p);
            }else if(!string.IsNullOrEmpty(FacultyID)){
               DepartmentService ds = new DepartmentService();
               Iesi.Collections.Generic.ISet<Profession> iset = ds.getProfessionSet(FacultyID);
                foreach(Profession pf in iset){
                   professionList.Add(pf);
               }
            }
            CouresService cs = new CouresService();
            int rows = Convert.ToInt32(context.Request.Form["rows"]);
            int page = Convert.ToInt32(context.Request.Form["page"]);
            object[] data = cs.searchCoures(professionList, YearNo, LevelNo, rows, page);
            Hashtable ht = new Hashtable();
            ht.Add("total", data[0]);
            ht.Add("rows", data[1]);
            String json = JsonConvert.SerializeObject(ht);
            context.Response.Write(json);
        }

        private void getCouresByID()
        {
            try
            {
                string CouresID = context.Request.Form.Get("CouresID");
                CouresService cs = new CouresService();
                Coures coures = cs.getCouresByID(CouresID);
                String json = JsonConvert.SerializeObject(coures);
                context.Response.Write(json);
            }
            catch (Exception e)
            {
                context.Response.Write("0");
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
                    else if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(o, context.Request.Form.Get(s), null);
                    }
                    else if (property.PropertyType == typeof(int))
                    {
                        property.SetValue(o, Convert.ToInt32(context.Request.Form.Get(s)), null);
                    }

                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }

            }
            return o;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
