using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using DataService.util;
using Domain.Entities;
using NHibernate.Criterion;
using System.Reflection;

namespace DataService.service.basic
{
    public abstract class BaseServiceImpl : BaseService
    {
        #region BaseService Members

        public Object get(Type t, string id)
        {
            using (ISession session = getSession())
            {
                return session.Get(t, id);
            }
        }

        public void save(object obj)
        {
            using (ISession session = getSession())
            {
                ITransaction tx = null;
                try
                {
                    tx = session.BeginTransaction();
                    PropertyInfo property = obj.GetType().GetProperty("Id");
                    Object Id = property.GetValue(obj, null);
                    if (Id == null || Id.Equals(""))
                    {
                        session.Save(obj);
                    }
                    else
                    {
                        session.Update(obj);
                    }
                    tx.Commit();
                }
                catch (Exception e)
                {
                    throw new ServiceException("保存失败！" + e.Message);
                    tx.Rollback();
                }
            }
        }

        public void del(object obj)
        {
            using (ISession session = getSession())
            {
                ITransaction tx = null;
                try
                {
                    tx = session.BeginTransaction();
                    session.Delete(obj);
                    tx.Commit();
                }
                catch (Exception e)
                {
                    tx.Rollback();
                    throw new ServiceException("删除失败！" + e.Message);
                }
            }
        }

        public ISession getSession()
        {
            return NHibernateHelper.GetSession();
        }

        public int getCount(ICriteria c)
        {
            c.SetProjection(Projections.RowCount());
            return (int)c.UniqueResult();
        }

        #endregion
    }
}
