using AsuManagement.OrdersCrud.Helpers;
using AsuManagement.OrdersCrud.Services.Commands.Orders.CreateOrder;
using Microsoft.AspNetCore.Mvc;

namespace AsuManagement.OrdersCrud.Presenters.Orders
{
    public class CreateOrderPresenter : IResponsePresenter<CreateOrderOutput>
    {
        public Task<IActionResult> Present(CreateOrderOutput response)
        {
            return Task.FromResult(response.Succeeded
                ? (IActionResult)JsonActionResult.Ok(new { createdOrderId = response.CreatedOrderId.Value })
                : JsonActionResult.BadRequest(response));
        }
    }
}
