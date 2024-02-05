using flyweight;

namespace flyweight
{
    //saves the memory usage.
    //it is usually used with the factory pattern
    internal class Program
    {
        //use sharing to support large numbers of fine-grained objects efficiently
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public interface IDiscountCalaculator
    {
        double GetDiscountValue(DateTime currentDate, string itemId = null);
    }

    public class DiscountCalcFactory
    {
        public IDiscountCalaculator GetDiscountCalc(string calcType)
        {
            IDiscountCalaculator calaculator = null;
            Dictionary<string, IDiscountCalaculator> calcLst = new Dictionary<string, IDiscountCalaculator>();

            if (calcLst.ContainsKey(calcType))
            {
                return calcLst[calcType];
            }
            else
            {
                switch (calcType)
                {
                    case "day":
                        calaculator = new DayDiscountCalc();
                        calcLst.Add("day", calaculator);
                        break;
                    case "item":
                        calaculator = new ItemsDiscountCalc();
                        calcLst.Add("item", calaculator);
                        break;
                }
                return calaculator;
            }

        }
    }


    public class DayDiscountCalc : IDiscountCalaculator
    {
        public double GetDiscountValue(DateTime currentDate, string itemId)
        {
            // call database to calc today discount
            return 0.15;
        }
    }

    public class ItemsDiscountCalc : IDiscountCalaculator
    {

        public double GetDiscountValue(DateTime currentDate, string itemId)
        {
            // call database to calc item discount
            return 0.10;
        }
    }
}

