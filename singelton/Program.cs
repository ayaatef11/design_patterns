using System.Security;

namespace singeltonPattern
{
    public class program
    {
       
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter base currency: ");
                var baseCurrency=Console.ReadLine();
                Console.WriteLine("Enter target currency: ");
                var targetCurrency=Console.ReadLine();
                Console.WriteLine("Enter amount: ");
                var amount=decimal.Parse(Console.ReadLine());//because readline only takes strings
               var converter= currencyConverter.Instance;
                var exchangedAmount=converter.convert(baseCurrency, targetCurrency,amount);
                Console.WriteLine($"{amount}{baseCurrency}={exchangedAmount}{targetCurrency}" );
                Console.WriteLine("-----------------------------------------");

            }
        }
    }
    /* public class currencyConverter
     {
         private IEnumerable<ExchangeRate> _exchangeRate;
       private currencyConverter()
         {
             LoadCurrency();

         }
         private static object _lock = new();//create an object to be locked
         private static currencyConverter _instance;//it will give null refernce exception because we haven't initialized it
         public static currencyConverter Instance
         {
             get
             {//this is called lazy initiaalization and we can provide it using the lazy keyword
                 lock (_lock)//create a lock
                 {
                     //to prevent making so many copies of a class if there are many threads in the program and waste our memory
                     //but what happens if there are two threads enetered the block at the same thime and make instances so we will make a lock
                     if (_instance == null) _instance = new();
                 }
                     return _instance;

             }
         }
         private void LoadCurrency()
         {
             Thread.Sleep(3000);
             _exchangeRate = new[]
           {
                 new ExchangeRate("usd","sar",3.75m),
                 new ExchangeRate("usd","egp",30.60m),
                 new ExchangeRate("sar","egp",8.16m)
             };
         }

         public decimal convert(string baseCurrency,string targetCurrency,decimal amount)
         {
             var exchangeRate=_exchangeRate.FirstOrDefault(rate=>rate._baseCurrency == baseCurrency&&rate._targetCurrency==targetCurrency);
             return amount * exchangeRate._rate;
         }
     }*/
    //lazy initialization 
    public class currencyConverter
    {
        private IEnumerable<ExchangeRate> _exchangeRate;
        private currencyConverter()
        {
            LoadCurrency();

        }
        private static readonly Lazy<currencyConverter> _instance=new Lazy<currencyConverter>(()=>new currencyConverter());
        public static currencyConverter Instance
        {
            get
            {
                return _instance.Value;

            }
        }
        private void LoadCurrency()
        {
            Thread.Sleep(3000);
            _exchangeRate = new[]
          {
                new ExchangeRate("usd","sar",3.75m),
                new ExchangeRate("usd","egp",30.60m),
                new ExchangeRate("sar","egp",8.16m)
            };
        }

        public decimal convert(string baseCurrency, string targetCurrency, decimal amount)
        {
            var exchangeRate = _exchangeRate.FirstOrDefault(rate => rate._baseCurrency == baseCurrency && rate._targetCurrency == targetCurrency);
            return amount * exchangeRate._rate;
        }
    }
    public class ExchangeRate
    {
        public ExchangeRate(string baseCurrency,string targetCurrency,decimal rate) {
            
           _baseCurrency = baseCurrency;
            _targetCurrency += targetCurrency;
            _rate = rate;
        }
        public string _baseCurrency {  get; }
       public string _targetCurrency { get;}
        public decimal _rate { get;  } = 0;
    }
}/*using System;

public class Singleton
{
    private static readonly Lazy<Singleton> instance = new Lazy<Singleton>(() => new Singleton());

    private Singleton()
    {
        // Private constructor to prevent instantiation outside the class
    }

    public static Singleton Instance => instance.Value;

    public void SomeMethod()
    {
        Console.WriteLine("Singleton method called.");
    }
}

class Program
{
    static void Main()
    {
        // Access the Singleton instance
        Singleton singleton = Singleton.Instance;

        // Call a method on the Singleton instance
        singleton.SomeMethod();
    }
}
*/