 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace builder
{
    internal class Employee
    {
        public Employee(string name,string email,decimal basicSalary) { 
        _name = name;
            _email = email;
            _basicSalary = basicSalary;
        }
        public string _name { get; }
        public string _email { get; }
        public decimal _basicSalary { get; }
    }
   

}
