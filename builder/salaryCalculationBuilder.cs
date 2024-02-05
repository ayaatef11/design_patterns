using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace builder
{
    internal class salaryCalculationBuilder
    {
        ///copy parameters of the parametrized constructor of the chosen class
        ///and making them here as attributes
        private int taxPercentage = 0;
        decimal bonusPercentage = 0;
        decimal educationPackage = 0m;
         decimal transportation = 0m;
        bool sendPayslipToEmployee = true;
        bool postResultToGl = true;
        //to make it a fluent api we make methods for every attribute
        //the return type is the same as the class type
        public salaryCalculationBuilder WithTaxes(int taxPercentage)
        {
            LogMessage($"{taxPercentage}% taxes will be duducted");
                this.taxPercentage = taxPercentage;
            return this;
        }

        public salaryCalculationBuilder WithBonus(decimal bonusPercentage) {
            LogMessage($"{taxPercentage}% taxes will be duducted");

            this.bonusPercentage = bonusPercentage;
            return this;
                   }

        public salaryCalculationBuilder WithPackage(decimal educationPackage) {
            LogMessage($"{taxPercentage}% taxes will be duducted");
            this.educationPackage = educationPackage;
            return this;
}

        public salaryCalculationBuilder WithTransportation(decimal transportation)
        {
            LogMessage($"{taxPercentage}% taxes will be duducted");
            this.transportation = transportation;
            return this;
        }

        public salaryCalculationBuilder WithSendPays(bool sendPays)
        {
            LogMessage($"{taxPercentage}% taxes will be duducted");
            this.sendPayslipToEmployee= sendPays;
            return this;
        }

        public salaryCalculationBuilder WithPostResult(bool postResult)
        {
            LogMessage($"{taxPercentage}% taxes will be duducted");
            this.postResultToGl = postResult;
            return this;
        }
       private void LogMessage(string message)
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public SalaryCalculator Build()
        {
            return new SalaryCalculator(taxPercentage ,  bonusPercentage ,  educationPackage
                  transportation ,  sendPayslipToEmployee , postResultToGl  );
        }
        //we haven't yet created the builder class
    }
}
