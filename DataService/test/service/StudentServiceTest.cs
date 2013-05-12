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
            DateTime dt = new DateTime();
            System.Console.WriteLine(dt.ToLongDateString());
            System.Console.WriteLine(dt.ToShortDateString());
            System.Console.WriteLine(dt.ToShortTimeString());
            System.Console.WriteLine(dt.ToLocalTime().ToString());
            System.Console.WriteLine(string.Format("yyyy-MM-dd",dt));
            System.Console.WriteLine(dt.ToString("yyyy-MM-dd"));
            System.Console.ReadLine();
        }
    }
}
