using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsuManagement.OrdersCrud.Domain.Interfaces;

namespace AsuManagement.OrdersCrud.Domain.Core.Entities
{
    public class Order : IEntity<int>
    {
        public int Id { get; private set; }
        public string Number { get; private set; }
        public DateTime Date { get; private set; }

        public int ProviderId { get; private set; }
        public Provider Provider { get; private set; }

        public List<OrderItem> OrderItems { get; private set; } = new();

        public Order(string number, DateTime date)
        {
            Number = number;
            Date = date;
        }

        public void SetNumber(string number) => Number = number;
        public void SetDate(DateTime date) => Date = date;

        public void SetProvider(Provider provider)
        {
            Provider = provider;
            ProviderId = provider.Id;
        }

        public void AddOrderItem(OrderItem item) => OrderItems.Add(item);
        public void RemoveOrderItem(OrderItem item) => OrderItems.Remove(item);
    }

    public class OrdersFilterModel {
        public List<string> Numbers { get; set; } = new();
        public List<int> Providers { get; set; } = new();
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }

    public class CreateOrderModel
    {
        public int ProviderId { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
    }

    public class EditOrderModel
    {
        public int? ProviderId { get; set; }
        public string? Number { get; set; }
        public DateTime? Date { get; set; }
    }
}
