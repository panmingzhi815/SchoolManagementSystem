using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace DataService.util
{
    class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null) { 
                return (new Configuration()).Configure().BuildSessionFactory();
            }
            return _sessionFactory;
            
        }

        public static ISession GetSession()
        {
            return GetSessionFactory().OpenSession();
        }
    }
}
