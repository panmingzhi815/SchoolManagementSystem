using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using DataService.util;
using Shinater.Logging;
using Domain.Entities;

namespace DataService.service.basic
{
    public abstract class BaseServiceImpl : BaseService
    {
        Logger logger = Logger.GetLogger("BaseServiceImpl");
        #region BaseService Members

        public string jsonPage(int page, int row, object obj)
        {
            return "";

        }

        public Object get(Type t, string id)
        {
            return getSession().Get(t, id);
        }

        public Object add(object obj)
        {
            using(ITransaction tx = getSession().BeginTransaction())
            try
            {
                logger.Log(Level.Config, "保存");
                Object o = getSession().Save(obj);
                getSession().Flush();
                tx.Commit();
                return o;
            }
            catch (Exception e)
            {
                tx.Rollback();
                logger.Log(Level.Config, e.Message);
                throw new ServiceException("保存失败！");
            }
        }

        public void del(object obj)
        {
            try
            {
                getSession().Delete(obj);
            }
            catch (Exception e)
            {
                throw new ServiceException("删除失败！");
            }
        }

        public void updata(object obj)
        {
            try
            {
                getSession().Update(obj);
            }
            catch (Exception e)
            {
                throw new ServiceException("修改失败！");
            }

        }

        public ISession getSession()
        {
            return NHibernateHelper.GetSession();
        }

        #endregion
    }
}
