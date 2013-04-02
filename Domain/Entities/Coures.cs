using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    //科目
    public class Coures
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
        //描述
        public virtual string Descript
        {
            get;
            set;
        }
    }
}
