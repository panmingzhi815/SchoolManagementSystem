using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Entities
{
    //班级
    public class ClassGrade : Department
    {
        [JsonIgnore]
        public virtual Profession Profession { get; set; }

        public virtual string ProfessionName { get; set; }

        [JsonIgnore]
        public virtual ISet<Student> studentList
        {
            set;
            get;
        }
    }
}
