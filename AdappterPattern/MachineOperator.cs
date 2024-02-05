using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AdappterPattern
{
    public  class MachineOperator
    {
        public string Name {  get; set; }
        public double BasicSalary { get; set; }
        public string ShiftCode {  get; set; }
    }
    public class salaryCalculator
    {
        public double calcSalary(Employee emp) => emp.BasicSalary * 1.5; 
    }
        public class SalaryAdapter : salaryCalculator
        {
            private Employee _emp;
            public double CalcSalary(MachineOperator _operator)
            {
                _emp = new Employee();
                _emp.BasicSalary = _operator.BasicSalary;
            return base.calcSalary(_emp);
            }
        }
    }

