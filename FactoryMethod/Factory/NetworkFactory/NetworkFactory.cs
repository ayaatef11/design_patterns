using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryMethod.Factory.NetWorkUtility;
namespace FactoryMethod.Factory.NetworkFactory
{
    internal class NetworkFactory
    {
        public INetwork GetNetwork(string type)//factory method
        {
            INetwork obj = null;
            if (type.ToLower().Equals("ping")) obj = new Ping();
            else if (type.ToLower().Equals("arp")) obj = new ARP();
            else if (type.ToLower().Equals("dns")) obj = new DNS();
            return obj;
        }
    }
}
