using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Domain.Entities;

namespace DataService.dao
{
    class DepartmentDAO
    {
        protected ISession Session { get; set; }

        public DepartmentDAO(ISession session)
        {
            Session = session;
        }
        public void save(Department department)
        {
            Session.Save(department);
            Session.Flush();
        }
        public void update(Department department)
        {
            Session.Update(department);
            Session.Flush();
        }
        public void delete(String id) {
            Session.Delete(get(id));
            Session.Flush();
        }
        public Department get(String id) {
            return Session.Get<Department>(id);
        }
    }
}
