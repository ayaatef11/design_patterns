using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace builder
{
    internal class SalaryCalculator
    {
        public SalaryCalculator(int taxPercentage = 0, decimal bonusPercentage = 0, decimal educationPackage = 0m
            , decimal transportation = 0m, bool sendPayslipToEmployee=true,bool postResultToGl=true) {
        _taxPercentage = taxPercentage;
            _bonusPercentage = bonusPercentage;
                _educationPackage = educationPackage;
            _transportation = transportation;
            _sendPayslipToEmployee=sendPayslipToEmployee;
        _postResultToGl=postResultToGl;
        }
        public int _taxPercentage { get; }
        public decimal _bonusPercentage { get; }
        public decimal _educationPackage { get;}
        public decimal _transportation { get; }
        public bool _sendPayslipToEmployee { get; }
        public bool _postResultToGl { get; }

        public decimal Calculate(Employee employee)
        {
            var bonus = employee._basicSalary * _bonusPercentage / 100;
            var taxes=employee._basicSalary*_taxPercentage / 100;
            var salary = employee._basicSalary + _educationPackage + _transportation + bonus - taxes;
            Console.ForegroundColor=ConsoleColor .Green;
            if(_sendPayslipToEmployee)Console.WriteLine(
                $"payslip has been sent to {employee._email}");
            if (_postResultToGl) Console.WriteLine($"salary voucher wiht total amount ({salary}EGP)has been sent to GL");
        Console.ForegroundColor=ConsoleColor .Red;
            return salary;
        }
    }
}
