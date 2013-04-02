using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    //班级
   public class ClassGrade
    {
        //主键
        public virtual string Id
        {
            get;
            set;
        }
        //编码
        public virtual string Sn
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
        //所属年份
        public virtual int CreateYear
        {
            get;
            set;
        }
        //班级拥有的学生
        public virtual List<Employee> EmployeeList
        {
            get;
            set;
        }
        //专业
        public virtual Profession Profession
        {
            get;
            set;
        }
    }
}
