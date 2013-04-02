using NHibernate;
using Domain.Entities;
using System;

namespace DataService.dao
{
    class CouresDAO
    {
        protected ISession Session { get; set; }

        public CouresDAO(ISession session)
        {
            Session = session;
        }
        public void save(Coures coures) {
            Session.Save(coures);
            Session.Flush();
        }
        public void update(Coures coures) {
            Session.Update(coures);
            Session.Flush();
        }
        public void delete(String id) {
            Session.Delete(get(id));
            Session.Flush();
        }
        public Coures get(String id) {
            return Session.Get<Coures>(id);
        }
    }
}
