using System;
using System.Globalization;
using System.Text;
using Course.Entities.Enums;

namespace Course.Entities
{
    internal class Order
    {
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> OrderItem { get; set; } = new List<OrderItem>();

        public Order()
        {

        }

        public Order(DateTime date, OrderStatus status, Client client)
        {
            Date = date;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            OrderItem.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            OrderItem.Remove(item);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            double sum = 0;
            sb.AppendLine("ORDER SUMMARY: ");
            sb.Append("Order Moment: ");
            sb.AppendLine(Date.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order Stauts: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.AppendLine(Client.Name + " (" + Client.BirthDate.ToString("dd/MM/yyyy") + ") - " + Client.Email);
            sb.AppendLine("Order Items: ");
            foreach(OrderItem item in OrderItem)
            {
                sb.Append(item.Product.Name);
                sb.Append(", $");
                sb.Append(item.Product.Price.ToString("F2",CultureInfo.InvariantCulture));
                sb.Append(", Quantity: ");
                sb.Append(item.Quantity);
                sb.Append(", Subtotal: $");
                sb.Append(item.SubTotal().ToString("F2",CultureInfo.InvariantCulture));
                sb.AppendLine("");

                sum += item.SubTotal();
            }
            sb.AppendLine("");
            sb.Append("TotalPrice: $");
            sb.Append(sum.ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }

    }
}
