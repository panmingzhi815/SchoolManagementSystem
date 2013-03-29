using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
   public class Person
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
        //姓名
        public virtual string Name
        {
            get;
            set;
        }
        //出生日期
        public virtual string Birth
        {
            get;
            set;
        }
        //电话
        public virtual string Telphone
        {
            get;
            set;
        }
        //地址
        public virtual string Address
        {
            get;
            set;
        }
        //性别
        public virtual string Sex
        {
            get;
            set;
        }
        //民族
        public virtual string Nation
        {
            get;
            set;
        }
        //单位
        public virtual Department Department
        {
            get;
            set;
        }
    }
}
