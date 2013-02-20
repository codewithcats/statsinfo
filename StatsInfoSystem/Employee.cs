using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StatsInfoSystem
{
    public class Department
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public Department Department { get; set; }
    }
}
