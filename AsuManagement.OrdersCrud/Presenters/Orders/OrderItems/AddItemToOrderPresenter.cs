using AsuManagement.OrdersCrud.Helpers;
using AsuManagement.OrdersCrud.Services.Commands.Orders.AddItemToOrder;
using AsuManagement.OrdersCrud.Services.Commands.Orders.CreateOrder;
using Microsoft.AspNetCore.Mvc;

namespace AsuManagement.OrdersCrud.Presenters.Orders
{
    public class AddItemToOrderPresenter : IResponsePresenter<AddItemToOrderOutput>
    {
        public Task<IActionResult> Present(AddItemToOrderOutput response)
        {
            return Task.FromResult(response.Succeeded
                ? (IActionResult)JsonActionResult.Ok(new { createdOrderId = response.CreatedOrderItemId.Value })
                : JsonActionResult.BadRequest(response));
        }
    }
}
