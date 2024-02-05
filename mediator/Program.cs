namespace mediator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public interface IMediator
    {
        public void interaction();
    }
    public class Mediator : IMediator
    {  
        Piece piece;
        Part part;
        Thing thing;
        public void interaction()
        {
            throw new NotImplementedException();
        }
    }
    public class Piece
    {
        IMediator mediator;
         public Piece(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public void Invoke()
        {
            mediator.interaction();
        }
    }
    public class Part
    {
        IMediator mediator { get; set; }
        public Part(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
    public class  Thing
    {
        IMediator Mediator { get; set; }
        public Thing(IMediator mediator)
        {
            Mediator = mediator;
        }



        //with mediator
        /*<Query Kind="Program" />

void Main()
{
	
}

public class LogicA {
	
	Mediator m;

	public void Do(){
		m.DoLogic("b");
	}
}

public class Mediator {
	
	public void DoLogic(string logic){
		if(logic == "b"){
			new LogicB().Do();
		}
	}
}

public class LogicB
{
	public void Do()
	{

	}
} c */










        /*<Query Kind="Program" />
		//problem************************************
void Main()
{

}

public class Product
{
	public int Id { get; set; }
}

public class Cart
{
	List<Product> products;

	public void AddProduct(Product product)
	{
		products.Add(product);
	}
}

public class Catalog
{
	List<Product> products;
	
	public List<Product> getProducts(){
		return products;
	}
}

public class ProductPage
{ 
	Cart cart;
	Catalog catalog;

	public ProductPage(Catalog catalog, Cart cart)
	{
		this.cart = cart;
		this.catalog = catalog;
	}

	public void AddToCart(int id)
	{
		var product = catalog.getProducts().First(x => x.Id == id);
		cart.AddProduct(product);
	}
	
	public void DisplayProducts(){
		// set ui elements from catalog
	}

}*/






        //solution**************************
        /*<Query Kind="Program" />

void Main()
{

}

public class Product
{
	public int Id { get; set; }
}

public class ShopContext {
	Cart cart; 
	Catalog catalog; 
	ProductPage page;
	
	public ShopContext(Cart cart, Catalog catalog, ProductPage page)
	{
		this.cart = cart;
		this.catalog = catalog;
		this.page = page;
		
		this.page.DisplayProducts(catalog.getProducts());
	}

	public void AddToCart(int id)
	{
		cart.AddProduct(catalog.getProducts().First(x => x.Id == id));
	}
}

public class Cart
{
	List<Product> products;

	public void AddProduct(Product product)
	{
		products.Add(product);
	}
}

public class Catalog
{
	List<Product> products;
	
	public List<Product> getProducts(){
		return products;
	}
}

public class ProductPage
{
	ShopContext context;
	public ProductPage(ShopContext context) => this.context = context;

	public void AddToCart(int id) => context.AddToCart(id);

	public void DisplayProducts(List<Product> products)
	{
		// set ui elements
	}
}*/











        //solution with interface
        /*<Query Kind="Program" />

void Main()
{

}

public class Product
{
	public int Id { get; set; }
}

public interface ICartInteraction {
	void AddToCart(int id);
}

public class ShopContext : ICartInteraction {
	Cart cart; 
	Catalog catalog; 
	ProductPage page;
	
	public ShopContext(Cart cart, Catalog catalog, ProductPage page)
	{
		this.cart = cart;
		this.catalog = catalog;
		this.page = page;
		
		this.page.DisplayProducts(catalog.getProducts());
	}

	public void AddToCart(int id)
	{
		cart.AddProduct(catalog.getProducts().First(x => x.Id == id));
	}
}

public class Cart
{
	List<Product> products;

	public void AddProduct(Product product)
	{
		products.Add(product);
	}
}

public class Catalog
{
	List<Product> products;
	
	public List<Product> getProducts(){
		return products;
	}
}

public class ProductPage
{
	ICartInteraction cart;
	public ProductPage(ICartInteraction cart) => this.cart = cart;

	public void AddToCart(int id) => cart.AddToCart(id);

	public void DisplayProducts(List<Product> products)
	{
		// set ui elements
	}
}*/

    }
}