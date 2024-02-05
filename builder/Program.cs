namespace builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            var builder=new salaryCalculationBuilder();
            while (true) {
                Console.WriteLine("select an option: ");
                Console.WriteLine("1.Add 20% bonus ");
                Console.WriteLine("2.Deduct 10% taxes ");
                Console.WriteLine("3.Add 2000 education backage ");
                Console.WriteLine("4.Add 1000 transportations ");
                Console.WriteLine("5.Send payslip to Employee ");
                Console.WriteLine("6.Post voucher to GL");
                Console.WriteLine("0.BUild");
            var option=int.Parse(Console.ReadLine());
                if (option == 1) builder.WithBonus(20);
                else if (option == 2) builder.WithTaxes(10);
                else if (option == 3) builder.WithPackage(2000);
                else if (option == 4) builder.WithTransportation(1000);
                else if (option == 5) builder.WithSendPays(true);
                else if (option == 6) builder.WithPostResult(true);
                else if (option == 0)
                    //we actually create the object here
                {
                    var calculator =builder.Build();
                    var employee = new Employee("eslam ashraf","eslam@ gmail.com",20000);
                    Console.ReadKey();
                    builder=new salaryCalculationBuilder();
                }
            }
        }
    }
}