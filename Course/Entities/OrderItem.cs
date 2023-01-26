using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.Entities;

namespace Course.Entities
{
    internal class OrderItem
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public OrderItem() { }

        public OrderItem(int quantity, Product product)
        {
            Quantity = quantity;
            Product = product;
        }

        public double SubTotal()
        {
            return Product.Price * Quantity;
        }
    }
}
