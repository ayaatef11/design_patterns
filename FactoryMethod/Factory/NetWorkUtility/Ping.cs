using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.Factory.NetWorkUtility
{
    public class Ping : INetwork
    {
        public void sendRequest(string ip, int timesSent)
        {
            Console.WriteLine("Ping request sent: " + ip + " " + timesSent + " times");
        }
    }
}
