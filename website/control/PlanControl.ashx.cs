using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using Domain.Entities;
using DataService.service.dao;
using NHibernate.Mapping;
using Iesi.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Domain.control
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class PlanControl : IHttpHandler
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
                case "getPlanByID":
                    getPlanByID();
                    break;
                case "searchPlan":
                    searchPlan();
                    break;
                case "savePlan":
                    saveCoures();
                    break;
                case "deleteExamPlan":
                    deleteExamPlan();
                    break;
                case "initStudentResult":
                    initStudentResult();
                    break;
                default:
                    context.Response.Write("-1");
                    break;
            }
        }

        private void initStudentResult()
        {
            try
            {
                string ExamPlanID = context.Request.Form.Get("ExamPlanID");
                PlanService planService = new PlanService();
                ExamPlan examPlan = planService.getExamPlanByID(ExamPlanID);

                IList<ExamPlan> examPlanList = new List<ExamPlan>();
                examPlanList.Add(examPlan);
                ExamResultService ers = new ExamResultService();
                object[] obj = ers.searchExamResult(examPlanList, int.MaxValue, 1);
                if (obj[1] != null) {
                    IList<ExamResult> examResultList = (IList<ExamResult>)obj[1];
                    foreach (ExamResult er in examResultList)
                    {
                      ers.del(er);
                    }
                }

                Student student = new Student();
                IList<Profession> professionList = new List<Profession>();
                professionList.Add(examPlan.Profession);
                student.ProfessionList = professionList;
                StudentService ss = new StudentService();
                object[] studentObjArr = ss.getStudentList(student, int.MaxValue, 1);

                if (studentObjArr[1] != null)
                {
                    IList<Student> studentList = (IList<Student>)studentObjArr[1];
                    foreach (Student s in studentList)
                    {
                        ExamResult examResult = new ExamResult();
                        examResult.ExamPlan = examPlan;
                        examResult.Student = s;
                        ers.save(examPlan);
                        IDictionary<string,string> map = new Dictionary<string,string>();
                        foreach (Coures c in examPlan.CouresSet)
                        {
                            map.Add(c.Name, "0");
                        }
                        examResult.CouresScoreMap = map;
                        ers.save(examResult);
                    }
                }
                context.Response.Write("1");
            }
            catch (Exception e)
            {
                context.Response.Write("0");
            }
            
            
        }

        private void deleteExamPlan()
        {
            try
            {
                string ExamPlanID = context.Request.Form.Get("ExamPlanID");
                PlanService planService = new PlanService();
                ExamPlan examPlan = planService.getExamPlanByID(ExamPlanID);
                examPlan.CouresSet = null;
                planService.save(examPlan);
                planService.del(examPlan);
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
                string ProfessionID = context.Request.Form.Get("Profession");
                string FacultyID = context.Request.Form.Get("Faculty");
                
                DepartmentService ds = new DepartmentService();
                Profession profession = ds.getProfessionByID(ProfessionID);
                Faculty faculty = ds.getFacultyByID(FacultyID);
                if (profession != null && faculty != null)
                {
                    ISet<Coures> couresSet = new HashedSet<Coures>();
                    string[] couresArr = context.Request.Form.GetValues("Coures");
                    CouresService cs = new CouresService();
                    foreach (string c in couresArr) {
                       Coures coures = cs.getCouresByID(c);
                       if (coures != null)
                       couresSet.Add(coures);
                    }

                    ExamPlan p = new ExamPlan();
                    setValue(p, context);
                    p.Profession = profession;
                    p.Faculty = faculty;
                    p.CouresSet = couresSet;
                    PlanService ps = new PlanService();
                    ps.save(p);
                    context.Response.Write("1");
                }
            }
            catch (Exception e)
            {
                context.Response.Write("0");
            }
        }

        private void searchPlan()
        {
            try
            {
                PlanService planService = new PlanService();
                DepartmentService ds = new DepartmentService();
                IList professionList = new ArrayList();
                string ProfessionID = context.Request.Form.Get("ProfessionID");
                string YearNo = context.Request.Form.Get("YearNo");
                string LevelNo = context.Request.Form.Get("LevelNo");
                if (!string.IsNullOrEmpty(ProfessionID)) {
                    Profession profession = ds.getProfessionByID(ProfessionID);
                    professionList.Add(profession);
                }
                
                int rows = Convert.ToInt32(context.Request.Form["rows"]);
                int page = Convert.ToInt32(context.Request.Form["page"]);
                object[] data = planService.searchPlan(professionList, YearNo, LevelNo, rows, page);
                Hashtable ht = new Hashtable();
                ht.Add("total", data[0]);
                ht.Add("rows", data[1]);
                String json = JsonConvert.SerializeObject(ht);
                context.Response.Write(json);
            }
            catch (Exception e) {
                context.Response.Write("0");
            }
        }

        private void getPlanByID()
        {
            try
            {
                string ExamPlanID = context.Request.Form.Get("ExamPlanID");
                PlanService planService = new PlanService();
                ExamPlan examPlan = planService.getExamPlanByID(ExamPlanID);
                String json = JsonConvert.SerializeObject(examPlan);
                context.Response.Write(json);
            }
            catch (Exception e) {
                context.Response.Write("0");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
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

    }
}
