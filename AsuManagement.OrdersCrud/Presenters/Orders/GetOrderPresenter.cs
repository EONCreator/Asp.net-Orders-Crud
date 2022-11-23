using AsuManagement.OrdersCrud.Helpers;
using AsuManagement.OrdersCrud.Services.Commands.GetOne.Orders;
using Microsoft.AspNetCore.Mvc;

namespace AsuManagement.OrdersCrud.Presenters.Orders
{
    public class GetOrderPresenter : IResponsePresenter<GetOrderOutput>
    {
        public Task<IActionResult> Present(GetOrderOutput response)
        {
            var result = response.Order;
            if (result == null)
                return Task.FromResult<IActionResult>(JsonActionResult.NotFound());

            return Task.FromResult<IActionResult>(JsonActionResult.Ok(result));
        }
    }
}
