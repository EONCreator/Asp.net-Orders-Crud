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

        public void SetNumber(string number)
        {
            if (number != null)
                Number = number;
        }

        public void SetDate(DateTime date) => Date = date;

        public void SetProvider(Provider provider)
        {
            Provider = provider;
            ProviderId = provider.Id;
        }

        public void AddOrderItem(OrderItem item)
        {
            if (item != null)
                OrderItems.Add(item);
        }

        public void RemoveOrderItem(OrderItem item)
        {
            if (item != null)
                OrderItems.Remove(item);
        }
    }
}
