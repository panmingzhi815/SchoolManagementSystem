using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;
using Newtonsoft.Json;

namespace Domain.Entities
{
   public class School : Department
    {
       [JsonIgnore]
       public virtual ISet<Faculty> facultyList
        {
            set;
            get;
        }
    }
}
