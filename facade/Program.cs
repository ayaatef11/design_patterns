public class program
{
    public static void Main()
    {/*//here the user does all these things and this is bad also if you want to change a thing in a class you need to apply these changes in all the classes 
        // also there is dublication you may see that onething is been called many times in many places in system fucntions
        shoppingBasket basket = new shoppingBasket();
        BasketItem item = new BasketItem();
        item.itemId = "123";item.itemPrice = 50;item.Quantity = 3;
        //check stock
        Inventory inventory = new Inventory();
        if (inventory.checkItemQuantity(item.itemId, item.Quantity)) basket.AddItem(item);
        //create inventpry order
        inventoryOrder inventpryOrder = new inventoryOrder();
        inventpryOrder.createOrder(basket);
        //create invoice 
        purchaseInvoice invoice = new purchaseInvoice();
        var inv = invoice.createInvoice(basket, "address:123,id=456,email=yy");
        //payment
        paymentProccesor payment= new paymentProccesor();
        payment.handlePayment(inv.netTota0, "acc-123456");
        //send sms
        smsNotification notification = new smsNotification();
        notification.sendSms("123", "invoice created");*/

        shoppingBasket basket = new shoppingBasket();
        basket.AddItem(new BasketItem {itemId="123",itemPrice=50,Quantity=3 });
        basket.AddItem(new BasketItem { itemId = "456", itemPrice = 60, Quantity = 5 });
        purchaseOrder order = new purchaseOrder();
        order.createOrder(basket, "name:mohammed,bank:3134,mobile:0100000000");
            
            }
    public class BasketItem
    {
        public string itemId { get; set; }
        public double itemPrice { get; set; }
        public double Quantity { get; set; }
    }
    public class  shoppingBasket
    {
        private List<BasketItem> _items = new List<BasketItem>();
        public void AddItem(BasketItem item)
        {
            _items.Add(item);
        }

        public void removeOneItem(string itemId)
        {
            var item = _items.Where(x => x.itemId == itemId).Single();
            if (item.Quantity > 0)
            {
                item.Quantity -= 1;
            }
        }
        public List <BasketItem>GetItems() { return _items; }
    }
    public class Inventory
    {
        public bool checkItemQuantity(string itemId,double quantity)
        {
            return quantity < 100;
        }
    }
    public class inventoryOrder
    {
        public string createOrder(shoppingBasket basket)
        {
            basket.GetItems();
            return $"orderr number is {System.Guid.NewGuid().ToString()}";
        }
    }
    public class purchaseInvoice
    {
        public double discount = 0;
        public double totalAmount = 0;
        public double netTota0;
        public purchaseInvoice createInvoice(shoppingBasket basket,string customerInfo)
        {
 var invoice =new purchaseInvoice(); 
            var items=basket.GetItems();
            foreach (var item in items)
            {
                invoice.totalAmount += item.itemPrice * item.Quantity;
            }
            if(items.Count > 5) { invoice.discount=20; }
            invoice.netTota0 = invoice.totalAmount - invoice.discount;
            return invoice;
        }
    }
    public class paymentProccesor
    {
        public bool handlePayment(double amount,string bankInfo)
        {
            return true;
        }
    }
    public class smsNotification
    {
        public void sendSms(string to,string msg)
        {

        }
                                                                                                                          
    }
    //it respects the single responsibility as its functionality is to collect the functiolnality of other classes but id i added another functonality like create products then 
    //here it doesn't apply the single responsibility
    public class purchaseOrder
    {
        // this is the facade class
        public bool createOrder(shoppingBasket basket, string custInfo)
        {
            //here the business logic of my code instead doing this in the main function
            Inventory inventory = new Inventory();
            bool isAvailable = true;
            foreach (var item in basket.GetItems())
                if (!inventory.checkItemQuantity(item.itemId, item.Quantity)) isAvailable = false;
            if (isAvailable)
            {
                //create inventpry order
                inventoryOrder inventpryOrder = new inventoryOrder();
                inventpryOrder.createOrder(basket);
                //create invoice 
                purchaseInvoice invoice = new purchaseInvoice();
                var inv = invoice.createInvoice(basket, "address:123,id=456,email=yy");
                //payment
                paymentProccesor payment = new paymentProccesor();
                payment.handlePayment(inv.netTota0, "acc-123456");
                //send sms
                smsNotification notification = new smsNotification();
                notification.sendSms("123", "invoice created");
                return true;
            }return false;
            //client will only prepare the basket in the main function
        }
    }
}
