using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Factory.NetWorkUtility
{
    internal class ARP : INetwork
    {
        public void sendRequest(string ip, int timesSent)
        {
            Console.WriteLine("ARP request sent: " + ip + " " + timesSent + " times");
        }
    }
}
