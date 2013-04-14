using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Entities
{
    //专业
    public class Profession : Department
    {
        [JsonIgnore]
        public virtual Faculty Faculty { get; set; }

        public virtual string FacultyName { get; set; }

        [JsonIgnore]
        public virtual ISet<ClassGrade> classGradeList
        {
            set;
            get;
        }
    }
}
