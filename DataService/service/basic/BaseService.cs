using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using NHibernate;

namespace DataService.service.basic
{
    interface BaseService
    {
        Object get(Type t, string id);

        Object add(Object obj);

        void del(Object obj);

        void updata(Object obj);

        ISession getSession();

    }
}
