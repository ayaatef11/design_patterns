using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Core
{
    public class EmployeesDataReader
    {

        public IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee
                {
                    FullName="Mahmoud Ahmad Elmahdy",
                    payItems=new List<PayItem>
                    {
                        new PayItem{Name="basic salary",Value=1000},
                        new PayItem{Name="Transportation",Value=250 }
                    }
                },
                new Employee
                {
                 FullName="Ibrahim Khalid Elnaggar ",
                 payItems=new List<PayItem>
                 {
                     new PayItem{Name="Basic salary",Value=1000},
                     new PayItem{Name="medical Insurance",Value=-150 }
                 }
                }
            };
        }
    }
}
