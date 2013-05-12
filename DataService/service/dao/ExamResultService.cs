using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.service.basic;
using Domain.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace DataService.service.dao
{
   public class ExamResultService : BaseServiceImpl
    {
       public object[] searchExamResult(IList<ExamPlan> examPlanList , int rows,int page) {
           using (ISession session = getSession())
           {
               object[] result = new object[2];
               ICriteria ic = session.CreateCriteria(typeof(ExamResult));
               //ic.Add(Restrictions.In("ExamPlan", examPlanList.ToArray()));
               ICriteria ic2 = (ICriteria)ic.Clone();
               result[0] = getCount(ic2);

               page = page > 0 ? page : 1;
               ic.SetFirstResult((page - 1) * rows);
               ic.SetMaxResults(rows);
               IList<ExamResult> examResultList = ic.List<ExamResult>();
               foreach (ExamResult er in examResultList) {
                   er.ExamPlanName = er.ExamPlan.Name;
                   er.StudentName = er.Student.Name;
                   er.StudentSN = er.Student.Sn;
               }
               result[1] = examResultList;
               return result;
           }
       }
    }
}
