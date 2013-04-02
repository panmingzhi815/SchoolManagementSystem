using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using DataService.util;

namespace DataService.service.basic
{
   public abstract class BaseServiceImpl : BaseService
    {
        #region BaseService Members

        public string jsonPage(int page, int row, object obj)
        {
            return "";
            
        }

        public Object get(string entityName, string id)
        {
            return getSession().Get(entityName, id);
        }

        public Object add(object obj)
        {
            try
            {
                return getSession().Save(obj);
            }
            catch (Exception e)
            {
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
            catch (Exception e) {
                throw new ServiceException("修改失败！");
            }
            
        }

        public ISession getSession() {
            return NHibernateHelper.GetSession();
        }

        #endregion
    }
}
