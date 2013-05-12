using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Student : Person
    {
        //所属班级
        [JsonIgnore]
        public virtual ClassGrade ClassGrade
        {
            get;
            set;
        }
        public virtual string ClassGradeName { get; set; }
        //所属班级
        [JsonIgnore]
        public virtual Profession Profession
        {
            get;
            set;
        }
        public virtual string ProfessionName { get; set; }
        public virtual IList<Profession> ProfessionList { get; set; }
        public virtual string Password { get; set; }

    }
}
