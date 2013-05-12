using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

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
        //年号
        public virtual string YearNo 
        { 
            get;
            set; 
        }
        //级别
        public virtual string LevelNo
        { 
            get;
            set;
        }
        public virtual string totalScore 
        {
            get;
            set;
        }
        //专业
        [JsonIgnore]
        public virtual Profession Profession
        { 
            get;
            set;
        }

        public virtual string ProfessionName
        { 
            get;
            set;
        }

        public virtual string FacultyName
        {
            get;
            set;
        }

        public virtual string ProfessionID { get; set; }

        public virtual string FacultyID { get; set; }
    }
}
