using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

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
        //身份证
        public virtual string IDcode
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
        //移动电话
        public virtual string MobilePhone
        {
            get;
            set;
        }
        //固定电话
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
        [JsonIgnore]
        public virtual Department Department
        {
            get;
            set;
        }
        public virtual string DpartmentName { get; set; }
        //单位
        public virtual DateTime EntryTime
        {
            get;
            set;
        }
        //图片
        public virtual string HeadImage
        {
            get;
            set;
        }
    }
}
