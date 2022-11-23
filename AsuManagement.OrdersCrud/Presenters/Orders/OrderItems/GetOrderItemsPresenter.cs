using AsuManagement.OrdersCrud.Helpers;
using AsuManagement.OrdersCrud.Services.Commands.GetMany.Orders;
using Microsoft.AspNetCore.Mvc;

namespace AsuManagement.OrdersCrud.Presenters.Orders
{
    public class GetOrderItemsPresenter : IResponsePresenter<GetOrderItemsOutput>
    {
        public Task<IActionResult> Present(GetOrderItemsOutput response) =>
            Task.FromResult<IActionResult>(JsonActionResult.Ok(response));
    }
}
