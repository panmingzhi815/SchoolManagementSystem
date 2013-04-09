using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    //专业
    public class Profession : Department
    {
        public virtual IList<ClassGrade> classGradeList
        {
            set;
            get;
        }
    }
}
