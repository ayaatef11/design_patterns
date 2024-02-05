
//encabsulate a request in an object
//request is the method call
//meaninig instead calling function do something you call the command and it calls the function
//advantages:
/*
1-viewing:
 put them in a queue and make deffered execution 
2-retry policy on your sql database
meaning you can execute them while looping over them and if a command fails you can retry it more than once
3- you can make rollbacks if it fails
ctrl+z uses the command pattern

 
 */
using System.Linq.Expressions;

namespace commandeed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //we need to convert requests to objects
            var laptop = new Product(1, "laptop", 20000, 10);
            var keyboard = new Product(2, "keyboard", 300, 50);
            var mouse = new Product(3, "Mouse", 150, 70);
            var order = new Order();
            var invoker = new commadInvoker();

            while(true)
            {
                Console.WriteLine("Select one of the below commands");
                Console.WriteLine("\t1. Add Laptop");
                Console.WriteLine("\t2. Add keyboard");
                Console.WriteLine("\t3. Add Mouse");
                Console.WriteLine("\t4. Save macro");
                Console.WriteLine("\t5. Replay macro");
                Console.WriteLine("\t6. Undo");
                Console.WriteLine("\t6. Redo");
                Console.WriteLine("\t0. Process and Exit");

                var commandId = int.Parse(Console.ReadLine());
                Product selectedProduct = null;
                if (commandId == 1)
                {
                    // selectedProduct = laptop;---->1
                    invoker.ExecuteCommands(new AddProductCommand(order, laptop, 1));
                    invoker.ExecuteCommands(new AddStockCommand(laptop, -1));
                }
                else if (commandId == 2)
                {
                    //selectedProduct = keyboard;-->1
                    invoker.ExecuteCommands(new AddProductCommand(order, keyboard, 1));
                    invoker.ExecuteCommands(new AddStockCommand(keyboard, -1));
                }
                else if (commandId == 3)
                {
                    //selectedProduct = mouse;---------->1
                    invoker.ExecuteCommands(new AddProductCommand(order, mouse, 1));
                    invoker.ExecuteCommands(new AddStockCommand(laptop, -1));
                }

                else if (commandId == 4)
                {
                    MacroStorage.Instance.createMacro(invoker.GetCommands());
                    invoker.clearCommands();
                }
                else if (commandId==5) {
                    ReplayMacro();
                }

                else if (commandId == 6)
                {
                    invoker.Undo();
                    invoker.Undo();
                    var totalQuantity = order.lines.Sum(x => x.Quantity);
                    var totalPrice = order.lines.Sum(x => x.Quantity * x.UnitPrice);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Order #{order.Id} created: Quantity={totalQuantity}, Total Price={totalPrice}");
                    Console.ForegroundColor = ConsoleColor.White;

                }

                else if (commandId == 7)
                {
                    invoker.Redo();
                    invoker.Redo();
                    var totalQuantity = order.lines.Sum(x => x.Quantity);
                    var totalPrice = order.lines.Sum(x => x.Quantity * x.UnitPrice);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Order #{order.Id} created: Quantity={totalQuantity}, Total Price={totalPrice}");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                ///then what if i want to redo to a specified order then i will use the memento pattern

                else if (commandId == 0)
                {
                    invoker.ExecuteCommands();
                    var totalQuantity = order.lines.Sum(x => x.Quantity);
                    var totalPrice = order.lines.Sum(x => x.Quantity * x.UnitPrice);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Order #{order.Id} created: Quantity={totalQuantity}, Total Price={totalPrice}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }

                order.AddProducts(selectedProduct,1);
                selectedProduct .AddStock(-1);
            }
            Console.WriteLine("----------------------");
        }
        void ReplayMacro()
        {
            Console.WriteLine("Enter Macro ID:");
            foreach(var macro in MacroStorage.Instance.GetMacros())
            {
                Console.WriteLine($"]t {macro.Id}");
            }
        }
    }
    public class Product
    {
        public Product(int id, string name,double unitPrice,double stockBalance)
        {
            Id = id;
            Name = name;
            UnitPrice = unitPrice;
            StockBalance = stockBalance;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public double StockBalance { get; set; }

        public void AddStock(double quantity)
        {
            StockBalance += quantity;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"product '{Name}' stock changed to {StockBalance}");
            Console.ForegroundColor= ConsoleColor.Red;
        }
    }
    public class OrderLine
    {
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }

    }
    public class Order
    {
        public int Id { get; }=Random.Shared.Next(1,1000);
        public List<OrderLine> _lines = new();
        public IEnumerable<OrderLine> lines => _lines.AsReadOnly();
        public void AddProducts(Product product, double quantity)
        {
            _lines.Add(new OrderLine { ProductId = product.Id, UnitPrice = product.UnitPrice, Quantity = quantity });
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Product '{product.Name}'added ,order now contains {_lines.Count}");
            Console.ForegroundColor = ConsoleColor.Red;
        }

        internal void removeProductsAt(int v)
        {
            _lines.RemoveAt(v);
        }
    }
    public interface ICommand
    {
        void Execute();//we won't make redo as it is like another execute
        void undo();
    }
    //command need  a receiver object
    //by macro you  can replay commands
    public class AddProductCommand : ICommand
    {
        public readonly double _quantity;
        public readonly Product _product;
        public  Order _order {  get; set; }//--->changeed inorder to adding macros
         public AddProductCommand(Order order,Product product,double quantity)
        {
            _quantity = quantity;
            _product = product;

            _order = order;

        }
        public void Execute()
        {
            _order.AddProducts(_product, _quantity); 
        }

        public void undo()
        {
            //we need here remove this product

            _order.removeProductsAt(_order.lines.Count()-1);
         }
    }

    public class AddStockCommand : ICommand 
    {
        //we needn't to turn the receiver int a property as the product is constant
        public readonly double _quantity;
        public readonly Product _product;
        public AddStockCommand(Product product,double quantity)
        {
          _product = product;
            _quantity = quantity;

        }
        public void Execute()
        {
            _product.AddStock(_quantity);
        }

        public void undo()
        {
            _product.AddStock(_quantity*-1);
        }
    
    }
    public class commadInvoker
    {
        //undo is made as lasti n first out so we will use the stack
        private List<ICommand> _commands=new();
        private Stack<ICommand> _executedCommands=new();
        private Stack<ICommand> _undoneCommands = new();
        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }
        public void ExecuteCommands() { 
        foreach(ICommand command in _commands)
            {
                ExecuteCommands(command);
            }
            clearCommands();
        }

        public  void ExecuteCommands(ICommand command)
        {
            command.Execute();
            _executedCommands.Push(command);
        }

        public void Undo()
        {
            var command=_executedCommands.Pop();
            command.undo();
            _undoneCommands.Push(command);
        }
        
        public void Redo()
        {
          var command=_undoneCommands.Pop();
            ExecuteCommands (command);
        }
        public void clearCommands()
        {
            _commands.Clear();
        }

        public  IEnumerable<ICommand> GetCommands()
        {
           return _commands.AsReadOnly();
        }
    }


    //using macros
    //keep all commands in a macro inorder to access them quickly
    public class Macro
    {
        public Macro(int id,IEnumerable<ICommand>commands)
        {
            
        }
        public int Id { get;  }
        public IEnumerable<ICommand> Commands { get; }
        public DateTime CreatedAt { get; set; }=DateTime.Now;
    }
    //singelton class
    public class MacroStorage
    {
        public MacroStorage()
        {

        }
        public static MacroStorage Instance { get; } = new MacroStorage();
        private List<Macro> _macros = new();
        public void createMacro(IEnumerable<ICommand> commands)
        {
            var macro = new Macro(_macros.Count + 1, commands.ToList());
            _macros.Add(macro);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Macro #{macro.Id} saved .");
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public IEnumerable<Macro> GetMacros() => _macros.AsReadOnly();
        public Macro GetMacro(int id)
        {

            return _macros.First(x=> x.Id == id);   
        }
    }
    //undo and redp
  
    }