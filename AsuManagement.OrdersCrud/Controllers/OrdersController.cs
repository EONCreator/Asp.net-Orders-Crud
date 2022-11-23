using Microsoft.AspNetCore.Mvc;
using AsuManagement.OrdersCrud.Interaction;

using AsuManagement.OrdersCrud.Services.Commands.GetMany.Orders;
using AsuManagement.OrdersCrud.Services.Commands.GetOne.Orders;

using AsuManagement.OrdersCrud.Services.Commands.Orders.CreateOrder;
using AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrder;
using AsuManagement.OrdersCrud.Services.Commands.Orders.DeleteOrder;

using AsuManagement.OrdersCrud.Services.Commands.Orders.AddItemToOrder;
using AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrderItem;
using AsuManagement.OrdersCrud.Services.Commands.OrderItems.DeleteOrderItem;

namespace AsuManagement.OrdersCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IInteractionBus _interactionBus;

        public OrdersController(IInteractionBus interactionBus)
        {
            _interactionBus = interactionBus;
        }

        #region Orders

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] OrdersFilterModel request)
        {
            return await _interactionBus.Send(new GetOrdersCommand(request.Numbers, request.Providers, 
                request.DateFrom, request.DateTo));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return await _interactionBus.Send(new GetOrderCommand(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOrderModel request)
        {
            return await _interactionBus.Send(new CreateOrderCommand(request.Number, request.Date, request.ProviderId));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] EditOrderModel request)
        {
            return await _interactionBus.Send(new EditOrderCommand(id, request.Number, request.Date, request.ProviderId));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return await _interactionBus.Send(new DeleteOrderCommand(id));
        }

        public class OrdersFilterModel
        {
            public string? Numbers { get; set; }
            public string? Providers { get; set; }
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

        #endregion

        #region OrderItems

        [HttpGet("getOrderItems")]
        public async Task<IActionResult> GetOrderItems([FromQuery] OrderItemsFilterModel request) {
            return await _interactionBus.Send(new GetOrderItemsCommand(request.OrderId, request.Name, request.Unit));
        }

        [HttpGet("getOrderItem")]
        public async Task<IActionResult> GetOrderItem([FromQuery(Name = "id")] int id) {
            return await _interactionBus.Send(new GetOrderItemCommand(id));
        }

        [HttpPost("{id}/addItemToOrder")]
        public async Task<IActionResult> AddItemToOrder([FromRoute] int id, [FromBody] AddOrderItemModel request)
        {
            return await _interactionBus.Send(new AddItemToOrderCommand(id, request.Name, request.Quantity, request.Unit));
        }

        [HttpPut("editOrderItem/{id}")]
        public async Task<IActionResult> EditOrderItem([FromRoute] int id, [FromBody] EditOrderItemModel request)
        {
            return await _interactionBus.Send(new EditOrderItemCommand(id, request.Name, request.Quantity, request.Unit));
        }

        [HttpDelete("deleteOrderItem/{id}")]
        public async Task<IActionResult> DeleteOrderItem([FromRoute] int id)
        {
            return await _interactionBus.Send(new DeleteOrderItemCommand(id));
        }

        public class OrderItemsFilterModel
        {
            public int OrderId { get; set; }
            public string? Name { get; set; }
            public decimal? Quantity { get; set; }
            public string? Unit { get; set; }
        }

        public class AddOrderItemModel
        {
            public int OrderId { get; set; }
            public string Name { get; set; }
            public decimal Quantity { get; set; }
            public string Unit { get; set; }
        }

        public class EditOrderItemModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public decimal? Quantity { get; set; }
            public string? Unit { get; set; }
        }

        #endregion
    }
}
