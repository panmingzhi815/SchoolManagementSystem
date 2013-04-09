using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
   public  class Department
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
       //描述图片
        public virtual string DescriptImage { 
            get;
            set;
        }
        //简单描述
        public virtual string SimpleDescript
        {
            get;
            set;
        }
        //详情描述
        public virtual string DetailDescript
        {
            get;
            set;
        }
    }
}
