using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    //班级
    public class ClassGrade : Department
    {
        public virtual IList<Student> classGradeList
        {
            set;
            get;
        }
    }
}
