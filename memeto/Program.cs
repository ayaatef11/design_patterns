

//used to memoize the state of the program
using System.Net.Http.Headers;

namespace memeto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public class orderMemento
    {//it must be immutable meaning it takes the values only one time and dont update them
        IEnumerable<OrderLine> _lines;


        public orderMemento(IEnumerable<OrderLine>lines)
        {
            _lines = lines;
        }

        public IEnumerable<OrderLine> GetLines() => _lines;
    }


    public class careTaker
    {//this is the store of memento
        private List<orderMemento> _mementos = new();

        public int AddMemontos(orderMemento memento)
        {
            _mementos.Add(memento);
            return _mementos.Count-1;
        }//return the index
        public orderMemento GetMemento(int index)
        {
            return _mementos[index];
        }//return the memento of an index
    }
    public class Order
    {//it is called orginator
        //this is  the object in which i save its state
        //it is the responsible for to do a copy of a memento object bbecause the state of the object can be private and it is dretermined by private fields  and the something in which it can access these private fields is the class itself and it is called the originator
        public int Id { get; }=Random.Shared.Next(1,1000);

        private List<OrderLine> _lines = new();
        public IEnumerable<OrderLine> Lines => _lines.AsReadOnly();
        public void AddProducts(Product product,double quantity)
        {
            _lines.Add(new OrderLine { ProductId = product.Id, unitPrice = product.unitPrice, Quantity = quantity });
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Product '{product.Name}'added ,order now contains {_lines.Count}");
            Console.ForegroundColor= ConsoleColor.Red;
         }
        public void RemoveProductAt(int index)
        {
            _lines.RemoveAt(index);
        }

        public orderMemento seveStateIntoMemento()
        {
            return new orderMemento(_lines.ToArray());
        }

        public void restoreStateFromMemento(orderMemento memento)
        {
            _lines = new List<OrderLine>(memento.GetLines());
        }
    }

    public class OrderLine
    {
        public int ProductId {  get; set; }
        public int unitPrice {  get; set; }
        public double Quantity {  get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public int unitPrice { get; set; }
        public string Name {  get; set; }
    }
}