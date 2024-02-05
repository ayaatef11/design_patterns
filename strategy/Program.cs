
namespace strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataReader = new customerDataReader();
            var customers=dataReader.GetCustomers();
            while (true)
            {
                Console.WriteLine("customer list :[1] mohammed ahmad elmahdy[2] ibrahim khalid ");
                Console.Write($"enter coustomer id: ");
                var customer1=int.Parse(Console.ReadLine());
                Console.Write("enter item quantity: ");
                var quantity=double.Parse(Console.ReadLine()); ;
                Console.WriteLine("enter unit price: ");
                var unitPrice=double .Parse(Console.ReadLine());
        /*        var customer =customers.First(x=>x.Id==customerId)
                 *//* var invoice = new invoice
                  {
                      customers = customer,
                      lines = new[]
                      {
                          new InvoiceLine { quantity = quantity, UnitPrice = unitPrice }



                      },
                      di*//*scountPercentage = customer.isillegable ? 0.02 : 0;*/









                  }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
            public bool isillegable {  get; set; }
    }

    public class customerDataReader
    {
        public IEnumerable<Customer> GetCustomers()
        {
            return new[]
            {
                new Customer { Id = 1,Name="mohammed ahmad mahdi",isillegable=true}
            
            ,new Customer{Id = 2,Name="ibrahim khalid elnaggar"}
            };
        }
    }
    public class  invoice
    { 
        public Customer customers { get; set; }

        public IEnumerable<InvoiceLine>lines { get; set; }
        public double totalPrice=> lines.Sum(l=>l.quantity*l.UnitPrice);
            public double discountPercentage {  get; set; }
            public double netPrice=>totalPrice-(totalPrice*discountPercentage);
    }

    public class InvoiceLine
    {
        public double UnitPrice { get; set; }
        public double quantity { get; set; }
    }

        public interface IcustomerDiscountStrategy
        {
            double calculateDiscount(double totalPrice);
        }

        public class NewCustomerDiscountStrategy : IcustomerDiscountStrategy
        {
            public double calculateDiscount(double totalPrice)
            {
                return totalPrice == 10000 ? 0.1 : 0;
            }
                    }

        }

    }