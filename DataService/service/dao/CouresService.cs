using System;
using System.Linq;
using System.Text;
using DataService.service.basic;
using Domain.Entities;
using NHibernate;
using NHibernate.Criterion;
using System.Collections;
using System.Collections.Generic;

namespace DataService.service.dao
{
    public class CouresService : BaseServiceImpl
    {
        public Coures getCouresByID(string couresID) {
            using (ISession session = getSession())
            {
                Coures c = (Coures)session.Get(typeof(Coures), couresID);
                c.ProfessionID = c.Profession.Id;
                c.FacultyID = c.Profession.Faculty.Id;
                return c;
            }
        }

        public object[] searchCoures(IList professionList, string YearNo, string LevelNo, int rows, int page)
        {
            using (ISession session = getSession())
            {
                object[] result = new object[2];
                ICriteria ic = session.CreateCriteria(typeof(Coures));
                ic.CreateCriteria("Profession");
                if (professionList != null && professionList.Count > 0)
                {
                    Object[] professionArr = new object[professionList.Count];
                    for (int i = 0; i < professionList.Count; i++)
                    {
                        professionArr[i] = professionList[i];
                    }
                    ic.Add(Restrictions.In("Profession", professionArr));
                }
                if (!string.IsNullOrEmpty(YearNo))
                {
                    ic.Add(Restrictions.Eq("YearNo", YearNo + ""));
                }

                if (!string.IsNullOrEmpty(LevelNo))
                {
                    ic.Add(Restrictions.Eq("LevelNo", LevelNo));
                }
                ICriteria ic2 = (ICriteria)ic.Clone();
                result[0] = getCount(ic2);

                rows = rows == 0 ? 100 : rows;
                page = page > 0 ? page : 1;
                ic.SetFirstResult((page - 1) * rows);
                ic.SetMaxResults(rows);
                IList<Coures> couresList = ic.List<Coures>();
                foreach (Coures c in couresList) {
                    c.ProfessionName = c.Profession.Name;
                }
                result[1] = couresList;

                return result;
            }
        }
    }
}
