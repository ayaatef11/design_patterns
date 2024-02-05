using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Core
{
    public  class PayRollSystemAdapter
    {
        private readonly PayItem _payitem;
        public PayRollSystemAdapter(PayItem payitem) { 
        _payitem = payitem;
        
        }
        public string Name =>_payitem.Name;
        public decimal Value => _payitem.isDeduction ? _payitem.Value * -1 : _payitem.Value;

    }
}
