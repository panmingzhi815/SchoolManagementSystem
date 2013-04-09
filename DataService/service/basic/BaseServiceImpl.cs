using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using DataService.util;
using Domain.Entities;
using NHibernate.Criterion;

namespace DataService.service.basic
{
    public abstract class BaseServiceImpl : BaseService
    {
        #region BaseService Members

        public Object get(Type t, string id)
        {
            return getSession().Get(t, id);
        }

        public Object add(object obj)
        {
            ISession session = getSession();
            using (ITransaction tx = session.BeginTransaction())
                try
                {
                    Object o = session.Save((Student)obj);
                    session.Flush();
                    tx.Commit();
                    return o;
                }
                catch (Exception e)
                {
                    tx.Rollback();
                    throw new ServiceException("保存失败！" + e.Message);
                }
        }

        public void del(object obj)
        {
            ISession session = getSession();
            using (ITransaction tx = session.BeginTransaction())
                try
                {
                    session.Delete(obj);
                    tx.Commit();
                }
                catch (Exception e)
                {
                    tx.Rollback();
                    throw new ServiceException("删除失败！" + e.Message);
                }
        }

        public void updata(object obj)
        {
            ISession session = getSession();
            using (ITransaction tx = session.BeginTransaction())
                try
                {
                    session.Update(obj);
                    tx.Commit();

                }
                catch (Exception e)
                {
                    tx.Rollback();
                    throw new ServiceException("修改失败！" + e.Message);
                }

        }

        public ISession getSession()
        {
            return NHibernateHelper.GetSession();
        }

        public int getCount(ICriteria c) { 
           c.SetProjection(Projections.RowCount());
           return (int)c.UniqueResult();
        }

        #endregion
    }
}
