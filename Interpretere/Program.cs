using System.Text.RegularExpressions;
using System.Xml;
namespace Interpretere
{
  
internal class Program
    {
        static void Main(string[] args)
        {
            var domainLanguage = "order x10 '2L water bottles' from Tesco";
            object value = Order.Parse(domainLanguage).Dump();
            Console.WriteLine(value);
        }
        const string optionalSpace = " ?";
        const string qty = "x(?<qty>\\d+)" + optionalSpace;
        const string product = "'(?<product>[\\w ]+)'" + optionalSpace;
        const string source = "from (?<source>\\w+)";
        const string orderCommand = "order" + optionalSpace + qty + product + source;

        public class Order
        {
            static Regex _regex = new Regex(orderCommand);
            public Order(int qty, string product,string source)
            {
                Qty=qty;
                Product=product;
                Source = source;
            }
            public int Qty {  get; set; }
            public string Product { get; set; }
            public string Source { get; set; }
            //interpreter
            public static Order Parse(string command)
            {
                var match=_regex.Match(command);
                if (!match.Success)
                {
                    return null;
                }
                var qty = int.Parse(match.Groups["qty"].Value);
                var product = match.Groups["product"].Value;
                var source = match.Groups["source"].Value;

                return new Order(qty, product, source);
            }

            
        }
    }
  

}