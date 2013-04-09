using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    class Faculty : Department
    {
        public virtual IList<Profession> professionList
        {
            set;
            get;
        }
    }
}
