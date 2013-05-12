using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping;

namespace Domain.Entities
{
    public class ExamResult
    {
        public virtual string Id { get; set; }
        public virtual ExamPlan ExamPlan { get; set; }
        public virtual string ExamPlanName { get; set; }
        public virtual Student Student { get; set; }
        public virtual string StudentName { get; set; }
        public virtual IDictionary<string,string> CouresScoreMap { get; set; }
        public virtual string StudentSN { get; set; }
    }
}
