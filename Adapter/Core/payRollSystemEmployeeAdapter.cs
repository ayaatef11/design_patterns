using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Core
{
    public class payRollSystemEmployeeAdapter
    {
        private readonly Employee _employee;
        private readonly IEnumerable<payRollSystemEmployeeAdapter> _payItems;
        public payRollSystemEmployeeAdapter(Employee employee) { 
        _employee = employee;
            _payItems = employee.payItems.Select(payItem => new payRollSystemEmployeeAdapter(employee)).ToList();
        
        }
        public IEnumerable<PayRollSystemAdapter> payItems => payItems;
        public string FullName =>_employee.FullName;
    }

}
