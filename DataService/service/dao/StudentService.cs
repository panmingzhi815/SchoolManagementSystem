using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.service.basic;
using Domain.Entities;
using NHibernate;

namespace DataService.service.dao
{
    public class StudentService : BaseServiceImpl
    {
        public object[] getStudentList(Student student, int rows, int page)
        {
            object[] result = new object[2];
            ISession session = getSession();
            ICriteria c = session.CreateCriteria(typeof(Student));
            result[0] = getCount(session.CreateCriteria(typeof(Student)));
            page = page > 0 ? page : 1;
            c.SetFirstResult((page - 1) * rows);
            c.SetMaxResults(rows);
            result[1] = c.List<Student>();
            return result;
        }
    }
}
