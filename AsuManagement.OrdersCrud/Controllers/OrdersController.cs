using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using AsuManagement.OrdersCrud.Services.Commands.Orders.CreateOrder;
using AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrder;
using AsuManagement.OrdersCrud.Services.Commands.Orders.DeleteOrder;
using AsuManagement.OrdersCrud.Domain.Services;
using Microsoft.EntityFrameworkCore;
using AsuManagement.OrdersCrud.Interaction;
using AsuManagement.OrdersCrud.Helpers;
using AsuManagement.OrdersCrud.Domain.Core.Entities;
using AsuManagement.OrdersCrud.Presenters.Orders;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
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
            return await _interactionBus.Send(new GetOrdersCommand(request!.Number, request!.ProviderId, 
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

        #endregion
    }
}
