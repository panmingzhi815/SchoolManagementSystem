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
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.control
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ExamResultControl : IHttpHandler
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
                case "getColumn":
                    getColumn();
                    break;
                case "searchExamResult":
                    searchExamResult();
                    break;
                case "saveExamResult":
                    saveExamResult();
                    break;
                case "deleteExamResult":
                    deleteExamResult();
                    break;
                default:
                    context.Response.Write("-1");
                    break;
            }
        }

        private void deleteExamResult()
        {
            throw new NotImplementedException();
        }

        private void saveExamResult()
        {
            try{
                string[] keys = context.Request.Form.AllKeys;
                ExamResultService res = new ExamResultService();
                ExamResult er = res.getExamResultByID(context.Request.Form.Get("Id"));
                IDictionary<string, string> map = new Dictionary<string, string>();
                foreach (string s in keys) 
                {
                    if (!s.Equals("Id") && !s.Equals("StudentSN") && !s.Equals("StudentName") && !s.Equals("ExamPlanName")) {
                        map.Add(s, context.Request.Form.Get(s));
                    }
                }
                er.CouresScoreMap = map;
                res.save(er);
                context.Response.Write("1");
            }
            catch (Exception e)
            {
                context.Response.Write("0");
            }
        }

        public void getColumn() { 
           DepartmentService ds = new DepartmentService();
            IList professionList = new ArrayList();
            string ProfessionID = context.Request.Form.Get("ProfessionID");
            string YearNo = context.Request.Form.Get("YearNo");
            string LevelNo = context.Request.Form.Get("LevelNo");
            if (!string.IsNullOrEmpty(ProfessionID))
            {
                Profession profession = ds.getProfessionByID(ProfessionID);
                professionList.Add(profession);
            }
            PlanService ps = new PlanService();
            object[] planObjArr = ps.searchPlan(professionList, YearNo, LevelNo, 
int.MaxValue, 1);
            if (planObjArr[1] != null)
            {
                IList<ExamPlan> examPlanList = (IList<ExamPlan>)planObjArr[1];
                if (examPlanList == null) return;
                ExamPlan ep = examPlanList.ElementAt(0);
                ArrayList newArrayList = new ArrayList();
                if (examPlanList.ElementAt(0).CouresSet == null) return;
                foreach (Coures c in examPlanList.ElementAt(0).CouresSet)
                {
                    newArrayList.Add(c.Name);
                }
                newArrayList.Sort();

                IList<Hashtable> columnList = new List<Hashtable>();
                foreach (string s in newArrayList) {
                    Hashtable ht = new Hashtable();
                    ht.Add("columnName",s);
                    columnList.Add(ht);
                }
                String json = JsonConvert.SerializeObject(columnList);
                context.Response.Write(json);

            }
        }

        private void searchExamResult()
        {
            DepartmentService ds = new DepartmentService();
            IList professionList = new ArrayList();
            string ProfessionID = context.Request.Form.Get("ProfessionID");
            string YearNo = context.Request.Form.Get("YearNo");
            string LevelNo = context.Request.Form.Get("LevelNo");
            if (!string.IsNullOrEmpty(ProfessionID))
            {
                Profession profession = ds.getProfessionByID(ProfessionID);
                professionList.Add(profession);
            }
            PlanService ps = new PlanService();
            object[] planObjArr = ps.searchPlan(professionList, YearNo, LevelNo,
int.MaxValue, 1);
            if (planObjArr[1] != null)
            {
                IList<ExamPlan> examPlanList = (IList<ExamPlan>)planObjArr[1];
                if (examPlanList == null && examPlanList.Count == 0) return;
                ExamResultService ers = new ExamResultService();
                IList<ExamPlan> planList = new List<ExamPlan>();
                planList.Add(examPlanList[0]);
                object[] examResultObjArr = ers.searchExamResult(planList, int.MaxValue, 1);
                if (examResultObjArr[1] != null)
                {
                    IList<ExamResult> examResultList = (IList<ExamResult>)examResultObjArr[1];
                    IList<Hashtable> examRsultMapList = new List<Hashtable>();
                    foreach (ExamResult er in examResultList)
                    {
                        Hashtable cht = new Hashtable();
                        cht.Add("Id", er.Id);
                        cht.Add("StudentSN", er.StudentSN);
                        cht.Add("StudentName", er.StudentName);
                        cht.Add("ExamPlanName", er.ExamPlanName);

                        if (er.CouresScoreMap != null)
                        {
                            ArrayList newArrayList = new ArrayList();
                            foreach (Coures c in planList.ElementAt(0).CouresSet)
                            {
                                newArrayList.Add(c.Name);
                            }
                            newArrayList.Sort();
                            foreach (string key in newArrayList)
                            {
                                if (er.CouresScoreMap.ContainsKey(key)) {
                                    cht.Add(key, er.CouresScoreMap[key]);
                                }
                                
                            }
                        }
                        examRsultMapList.Add(cht);
                    }
                    Hashtable ht = new Hashtable();
                    ht.Add("total", examResultObjArr[0]);
                    ht.Add("rows", examRsultMapList);
                    String json = JsonConvert.SerializeObject(ht);
                    context.Response.Write(json);
                }
            }
        }

        private void getExamResultByID()
        {
            throw new NotImplementedException();
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
