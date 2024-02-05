using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Factory.NetWorkUtility
{
    internal class DNS : INetwork
    {
        public void sendRequest(string ip, int timesSent)
        {
            Console.WriteLine("DNS request sent: " + ip + " " + timesSent + " times");
        }
    }
}
