using LTWeb_05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTWeb_05.Helpers
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }
        public Cart()
        {
            this.Items = new List<CartItem>();
        }
        public void AddItem(CartItem item)
        {
            this.Items.Add(item);
        }
    }
     public class CartItem
        {
            public Product product { get; set; }
            public int Quantity { get; set; }
        }
}