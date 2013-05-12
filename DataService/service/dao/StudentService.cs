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
    public class StudentService : BaseServiceImpl
    {
        public object[] getStudentList(Student student, int rows, int page)
        {
            object[] result = new object[2];
            ISession session = getSession();
            ICriteria c = session.CreateCriteria(typeof(Student));
            if (!string.IsNullOrEmpty(student.Name)) {
                c.Add(Restrictions.Like("Name",student.Name,MatchMode.Anywhere));
            }
            if (!string.IsNullOrEmpty(student.Sex))
            {
                c.Add(Restrictions.Eq("Sex", student.Sex));
            }
            if (!string.IsNullOrEmpty(student.IDcode))
            {
                c.Add(Restrictions.Like("IDcode", student.IDcode, MatchMode.Anywhere));
            }
            if (!string.IsNullOrEmpty(student.Sn))
            {
                c.Add(Restrictions.Like("Sn", student.Sn, MatchMode.Anywhere));
            }
            if (student.ProfessionList != null && student.ProfessionList.Count > 0)
            {
                c.Add(Restrictions.In("Profession", student.ProfessionList.ToArray()));
            }
            ICriteria c2 = (ICriteria)c.Clone();
            result[0] = getCount(c2);
            page = page > 0 ? page : 1;
            c.SetFirstResult((page - 1) * rows);
            c.SetMaxResults(rows);
            IList<Student> studentList = c.List<Student>();
            foreach (Student s in studentList) {
                s.ProfessionName = s.Profession.Name;
            }
            result[1] = studentList;
            return result;
        }

        public Student login(string Sn, string password) {
            using (ISession session = getSession()) {
                
                if (string.IsNullOrEmpty(Sn) || string.IsNullOrEmpty(password))
                    return null;
                ICriteria c = session.CreateCriteria(typeof(Student));
                c.Add(Restrictions.Eq("Sn",Sn));
                c.Add(Restrictions.Eq("Password", password));
                object o = c.UniqueResult();
                return c.UniqueResult() == null ? null : (Student)c.UniqueResult();
            }
        }
    }
}
