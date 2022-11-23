using AsuManagement.OrdersCrud.Domain.Interfaces;

namespace AsuManagement.OrdersCrud.Domain.Core.Entities
{
    public class OrderItem : IEntity<int>
    {
        public int Id { get; private set; }

        public int OrderId { get; private set; }
        public Order Order { get; private set; }

        public string Name { get; private set; }
        public decimal Quantity { get; private set; }
        public string Unit { get; private set; }

        public OrderItem(string name, decimal quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }

        public void SetName(string name)
        {
            if (name != null)
                Name = name;
        }

        public void SetQuantity(decimal quantity) => Quantity = quantity;
        public void SetUnit(string unit) => Unit = unit;

        public void SetOrder(Order order)
        {
            if (order != null)
            {
                Order = order;
                OrderId = order.Id;
            }
        }
    }
}
