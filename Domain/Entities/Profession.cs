using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    //专业
    public class Profession
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
        //简介
        public virtual string SimpleDescript
        {
            get;
            set;
        }
        //详介
        public virtual string FullDescript
        {
            get;
            set;
        }
        //科目列表
        public virtual List<Coures> CouresList
        {
            get;
            set;
        }
    }
}
