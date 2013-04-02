using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using DataService.service.dao;

namespace DataService.test.service
{
    class StudentServiceTest
    {
        public static void Main(string[] args) {
            Student s = new Student();
            s.Name = "pmz";
            StudentService ss = new StudentService();
            ss.add(s);
            Console.WriteLine(s.Id);

            Console.ReadLine();
        }
    }
}
