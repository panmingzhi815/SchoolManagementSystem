using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Student : Person
    {
        //所属班级
        public virtual ClassGrade ClassGrade
        {
            get;
            set;
        }

    }
}
