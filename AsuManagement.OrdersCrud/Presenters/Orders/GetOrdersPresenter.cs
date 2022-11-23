using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using AsuManagement.OrdersCrud.Helpers;
using AsuManagement.OrdersCrud.Services.Commands.Orders;
using AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrder;
using Microsoft.AspNetCore.Mvc;

namespace AsuManagement.OrdersCrud.Presenters.Orders
{
    public class GetOrdersPresenter : IResponsePresenter<GetOrdersOutput>
    {
        public Task<IActionResult> Present(GetOrdersOutput response) =>
            Task.FromResult<IActionResult>(JsonActionResult.Ok(response));
    }
}
