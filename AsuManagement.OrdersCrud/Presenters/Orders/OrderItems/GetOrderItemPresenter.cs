using AsuManagement.OrdersCrud.Helpers;
using AsuManagement.OrdersCrud.Services.Commands.GetOne.Orders;
using Microsoft.AspNetCore.Mvc;

namespace AsuManagement.OrdersCrud.Presenters.Orders
{
    public class GetOrderItemPresenter : IResponsePresenter<GetOrderItemOutput>
    {
        public Task<IActionResult> Present(GetOrderItemOutput response)
        {
            var result = response.OrderItem;
            if (result == null)
                return Task.FromResult<IActionResult>(JsonActionResult.NotFound());

            return Task.FromResult<IActionResult>(JsonActionResult.Ok(result));
        }
    }
}
