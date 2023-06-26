using New_Pie_Shop;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Xml.Linq;

class Program
{
    // creates a new order of type 'delivery'
    static Order createDeliveryOrder()
    {
        var order = new Order("Delivery");
        while (true)
        {
            var itemName = promptItem();
            if (itemName == "finished")
                break;

            promptPrice(itemName, order);
        }

        // prompts user to enter delivery address
        Console.WriteLine("Enter delivery address: ");
        order.DeliveryAddress = Console.ReadLine();

        return order;
    }

     // creates a new order of type 'takeoout'
    static Order createTakeoutOrder()
    {
        var order = new Order("Takeout");
        while (true)
        {
            String itemName = promptItem();
            if (itemName == "finished")
                break;

            promptPrice(itemName, order);
        }

        return order;
    }

    // prints the entire list on console
    static void printWholeList(List<Order> orders)
    {
        Console.WriteLine();

        for (int i = 0; i < orders.Count; i++)
        {
            var order = orders[i];
            Console.WriteLine($"Order {i + 1}");
            Console.WriteLine($"Type: {order.OrderType}");
            Console.WriteLine("Items:");
            foreach (var item in order.Items)
            {
                Console.WriteLine($"- {item.Name} (Price: {item.Price})");
            }
            Console.WriteLine($"Subtotal: {order.calcSubtotal()}");
            if (order.OrderType == "Delivery")
            {
                Console.WriteLine($"Delivery Address: {order.DeliveryAddress}");
            }
            Console.WriteLine();
        }
    }
    //main method
    static void Main(string[] args)
    {
        int count = 0;
        string item;
        string address;
        float itemPrice;
        var orders = new List<Order>();
        int index = 0;
        while (true)
        {
            orderMessage();

            // prompts the user to enter a number from a 1-3 to choose what thwy want to do 
            Console.WriteLine("Enter your choice here:");
            var choice = Console.ReadLine();
            
            //different cases for different user inputs 
            switch (choice)
            {
                case "1":
                    var deliveryOrder = createDeliveryOrder();
                    orders.Add(deliveryOrder);
                    break;
                case "2":
                    var takeoutOrder = createTakeoutOrder();
                    orders.Add(takeoutOrder);
                    break;
                case "3":
                    printWholeList(orders);
                    return;
                default:
                    //makes sure that user only puts in acceptable inputs 
                    Console.WriteLine("Invalid choice. Please try again."); 
                    break;
            }
        }
        // We are resuing theses blocks of code to simplify the entire program 
        // print the introductory msg
        static void orderMessage()
        {
            Console.WriteLine("\nBelow are the actions you can take:");
            Console.WriteLine("1.Take Delivery Order");
            Console.WriteLine("2.Create Takeout Order");
            Console.WriteLine("3. Exit menu");
        }

    }
  
    // prompts the user to enter a new item
    static String promptItem()
    {
        Console.WriteLine("Enter item name (or 'finished' to finish adding items): ");
        return Console.ReadLine();
    }

    // prompts the user to enter item price
    static void promptPrice(string itemName, Order order)
    {
        Console.WriteLine("Enter item price: ");
        decimal itemPrice = decimal.Parse(Console.ReadLine());

        var item = new Item { Name = itemName, Price = itemPrice };
        order.AddItem(item);
    }
}








