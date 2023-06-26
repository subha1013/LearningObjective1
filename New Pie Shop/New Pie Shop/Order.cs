using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Pie_Shop
{
    internal class Order
    {
    public string OrderType { get; set; } //type of order 
        public List<Item> Items { get; set; } // all items inside of the order 
        public decimal Subtotal { get; set; } // grand total without tax 
        public string DeliveryAddress { get; set; } // user puts in address

        //constructor for the order class 
        public Order(string orderType)
        {
            OrderType = orderType;
            Items = new List<Item>();
            Subtotal = 0.0m;
            DeliveryAddress = "";
        }
        // adds new item
        internal void AddItem(Item newItem)
        {
            Items.Add(newItem); 
        }

       
        //calculates the total amount 
        public decimal calcSubtotal()
        {

            foreach (Item i in Items)
            {
                Subtotal += i.Price;
            }

            return Subtotal;
        }
    }
}
