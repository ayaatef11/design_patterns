using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Core
{
    public class Employee
    {
        public string FullName { get; set; }
        public IEnumerable<PayItem> payItems { get; set; }
    }
}
