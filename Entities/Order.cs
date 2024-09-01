﻿using Course.Entities.Enums;
using System.Globalization;
using System.Text;

namespace Course.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Add(item);
        }

        public double Total()
        {
            double sum = 0;
            foreach (OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order Summary:");
            sb.AppendLine($"Order Moment: {Moment.ToString("dd/MM/yyyy HH:mm:ss")}");
            sb.AppendLine($"OrderStatus: {Status}");
            sb.AppendLine($"Client: {Client}");
            sb.AppendLine("Order Items:");
            foreach(OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine($"Total Price: ${Total().ToString("F2", CultureInfo.InvariantCulture)}");

            return sb.ToString();
        }
    }
}
