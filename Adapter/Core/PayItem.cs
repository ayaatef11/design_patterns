using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Core
{
    public class PayItem
    {
        public string Name { get; set; }
        public bool isDeduction { get; set; }
        public decimal Value { get; set; }
   
    }
}
