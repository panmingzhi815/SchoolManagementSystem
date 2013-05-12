using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.service.basic;
using Domain.Entities;
using NHibernate;
using NHibernate.Criterion;

namespace DataService.service.dao
{
    public class TeacherService : BaseServiceImpl
    {
        public object[] getTeacherList(Teacher teacher, int rows, int page)
        {
            object[] result = new object[2];
            ISession session = getSession();
            ICriteria c = session.CreateCriteria(typeof(Teacher));
            if (!string.IsNullOrEmpty(teacher.Name))
            {
                c.Add(Restrictions.Like("Name", teacher.Name, MatchMode.Anywhere));
            }
            if (!string.IsNullOrEmpty(teacher.Sex))
            {
                c.Add(Restrictions.Eq("Sex", teacher.Sex));
            }
            if (!string.IsNullOrEmpty(teacher.Sn))
            {
                c.Add(Restrictions.Eq("Sn", teacher.Sn));
            }
            if (!string.IsNullOrEmpty(teacher.IDcode))
            {
                c.Add(Restrictions.Like("IDcode", teacher.IDcode, MatchMode.Anywhere));
            }
            ICriteria c2 = (ICriteria)c.Clone();
            result[0] = getCount(c2);
            page = page > 0 ? page : 1;
            c.SetFirstResult((page - 1) * rows);
            c.SetMaxResults(rows);
            result[1] = c.List<Teacher>();
            return result;
        }
    }
}
