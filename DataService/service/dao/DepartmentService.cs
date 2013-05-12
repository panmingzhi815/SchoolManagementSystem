using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.service.basic;
using Domain.Entities;
using NHibernate;
using Iesi.Collections.Generic;
using System.Collections;

namespace DataService.service.dao
{
    public class DepartmentService : BaseServiceImpl
    {
        public IList<EasyuiTree> getDepartmentTree()
        {
            using (ISession session = getSession())
            {
                IList<EasyuiTree> resultList = new List<EasyuiTree>();
                ICriteria ic = session.CreateCriteria(typeof(School));
                IList<School> list = ic.List<School>();
                foreach (School s in list)
                {
                    Hashtable sht = new Hashtable();
                    sht.Add("type", "学校");
                    School s_get = session.Get<School>(s.Id);
                    EasyuiTree SchoolNode = new EasyuiTree(s_get.Id, s_get.Name, "open", "icon-school", sht, null);
                    IList<EasyuiTree> FacultyNodeList = new List<EasyuiTree>();
                    ISet<Faculty> facultyList = s_get.facultyList;
                    foreach (Faculty f in facultyList)
                    {
                        Hashtable fht = new Hashtable();
                        fht.Add("type", "院系");
                        Faculty f_get = session.Get<Faculty>(f.Id);
                        EasyuiTree FacultyNode = new EasyuiTree(f_get.Id, f_get.Name, "open", "icon-faculty", fht, null);
                        IList<EasyuiTree> ProfessionNodeList = new List<EasyuiTree>();
                        ISet<Profession> professionList = f_get.professionList;
                        foreach (Profession p in professionList)
                        {
                            Hashtable pht = new Hashtable();
                            pht.Add("type", "专业");
                            Profession p_get = session.Get<Profession>(p.Id);
                            EasyuiTree ProfessionNode = new EasyuiTree(p_get.Id, p_get.Name, "open", "icon-profession", pht, null);
                            IList<EasyuiTree> classGradeNodeList = new List<EasyuiTree>();
                            ISet<ClassGrade> classGradeList = p_get.classGradeList;
                            foreach (ClassGrade c in classGradeList)
                            {
                                Hashtable cht = new Hashtable();
                                cht.Add("type", "班级");
                                ClassGrade c_get = session.Get<ClassGrade>(c.Id);
                                EasyuiTree ClassGradeNode = new EasyuiTree(c_get.Id, c_get.Name, "open", "icon-classgrade", cht, null);
                                classGradeNodeList.Add(ClassGradeNode);
                            }
                            ProfessionNode.children = classGradeNodeList;
                            ProfessionNodeList.Add(ProfessionNode);
                        }
                        FacultyNode.children = ProfessionNodeList;
                            FacultyNodeList.Add(FacultyNode);
                    }
                    SchoolNode.children = FacultyNodeList;
                    resultList.Add(SchoolNode);
                }
                return resultList;

            }
        }

        public IList<Faculty> getSchoolList()
        {
            using (ISession session = getSession())
            {
                ICriteria ic = session.CreateCriteria(typeof(School));
                IList<School> schoolList = ic.List<School>();
                return schoolList;
            }
        }

        public IList<Faculty> getFacultyList() {
            using (ISession session = getSession())
            {
               ICriteria ic = session.CreateCriteria(typeof(Faculty));
               IList<Faculty> facultyList = ic.List<Faculty>();
               return facultyList;
            }
        }

        public ISet<Profession> getProfessionSet(String facultyID)
        {
            using (ISession session = getSession())
            {
                Faculty faculty = (Faculty)session.Get(typeof(Faculty), facultyID);
                NHibernateUtil.Initialize(faculty.professionList);
                return faculty.professionList;
            }
        }

        public ISet<ClassGrade> getClassGradeSet(string professionID) {
            using (ISession session = getSession())
            {
                Profession profession = (Profession)session.Get(typeof(Profession), professionID);
                NHibernateUtil.Initialize(profession.classGradeList);
                return profession.classGradeList;
            }
        }

        public Faculty getFacultyByID(string FacultyID)
        {
            using (ISession session = getSession())
            {
                Faculty faculty = (Faculty)session.Get(typeof(Faculty), FacultyID);
                return faculty;
            }
        }

        public Profession getProfessionByID(string ProfessionID)
        {
            using (ISession session = getSession())
            {
                Profession profession = (Profession)session.Get(typeof(Profession), ProfessionID);
                return profession;
            }
        }

        public ClassGrade getClassGradeByID(string ClassGradeID)
        {
            using (ISession session = getSession())
            {
                ClassGrade classGrade = (ClassGrade)session.Get(typeof(ClassGrade), ClassGradeID);
                return classGrade;
            }
        }
    }
}
