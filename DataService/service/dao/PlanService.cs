using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.service.basic;
using Domain.Entities;
using System.Collections;
using NHibernate;
using NHibernate.Criterion;

namespace DataService.service.dao
{
    public class PlanService : BaseServiceImpl
    {

        public ExamPlan getExamPlanByID(string planID)
        {
            using (ISession session = getSession())
            {
                ExamPlan examPlan = (ExamPlan)session.Get(typeof(ExamPlan),planID);
                examPlan.ProfessionID = examPlan.Profession.Id;
                examPlan.FacultyID = examPlan.Profession.Faculty.Id;
                NHibernateUtil.Initialize(examPlan.CouresSet);
                return examPlan;
            }
        }

        public object[] searchPlan(IList professionList, string YearNo, string LevelNo, int rows, int page)
        {
            using (ISession session = getSession())
            {
                object[] result = new object[2];
                ICriteria ic = session.CreateCriteria(typeof(ExamPlan));
                ic.CreateCriteria("Profession");
                if (professionList != null && professionList.Count > 0)
                {
                    Object[] professionArr = new object[professionList.Count];
                    for (int i = 0; i < professionList.Count; i++)
                    {
                        professionArr[i] = professionList[i];
                    }
                    ic.Add(Restrictions.In("Profession", professionArr));
                }
                if (!string.IsNullOrEmpty(YearNo))
                {
                    ic.Add(Restrictions.Eq("YearNo", YearNo + ""));
                }

                if (!string.IsNullOrEmpty(LevelNo))
                {
                    ic.Add(Restrictions.Eq("LevelNo", LevelNo));
                }
                ICriteria ic2 = (ICriteria)ic.Clone();
                result[0] = getCount(ic2);

                page = page > 0 ? page : 1;
                ic.SetFirstResult((page - 1) * rows);
                ic.SetMaxResults(rows);
                IList<ExamPlan> planList = ic.List<ExamPlan>();
                foreach (ExamPlan p in planList)
                {
                    p.ProfessionName = p.Profession.Name;
                    p.FacultyName = p.Faculty.Name;
                    p.CouresCount = Convert.ToString(p.CouresSet.Count);
                    p.BeginTimeStr = p.BeginTime.ToString("yyyy-MM-dd");
                }
                result[1] = planList;

                return result;
            }
        }
    }
}
