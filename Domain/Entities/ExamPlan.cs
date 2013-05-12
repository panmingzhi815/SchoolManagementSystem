using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Entities
{
   public class ExamPlan
    {
        public virtual string Id 
        { 
            get;
            set;
        }

        //名称
        public virtual string Name 
        { 
            get;
            set;
        }

        //开考时间
        public virtual DateTime BeginTime 
        { 
            get;
            set;
        }

        public virtual string BeginTimeStr { get; set; }

        //院系
        [JsonIgnore]
        public virtual Faculty Faculty 
        { 
            get;
            set;
        }

        public virtual string FacultyName 
        { 
            get;
            set;
        }

        //专业
        [JsonIgnore]
        public virtual Profession Profession 
        { 
            get;
            set;
        }

        public virtual string ProfessionName 
        { 
            get;
            set;
        }

        //年号
        public virtual string YearNo
        {
            get;
            set;
        }

        //级别
        public virtual string LevelNo
        {
            get;
            set;
        }

        //课程列表
        public virtual ISet<Coures> CouresSet 
        { 
            get;
            set;
        }

        //课程数量
        public virtual string CouresCount 
        { 
            get; 
            set;
        }

        public virtual string ProfessionID { get; set; }

        public virtual string FacultyID { get; set; }
    }
}
