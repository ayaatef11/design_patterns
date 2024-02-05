using FactoryMethod.Factory.NetWorkUtility;
using FactoryMethod.Factory.NetworkFactory;
namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
          NetworkFactory n=new NetworkFactory();
            var bb = n.GetNetwork("ping");
            bb.sendRequest("dfd", 44);
        }
    }
}