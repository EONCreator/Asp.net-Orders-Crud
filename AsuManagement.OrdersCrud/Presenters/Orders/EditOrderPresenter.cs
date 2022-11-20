using AsuManagement.OrdersCrud.Helpers;
using AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrder;
using Microsoft.AspNetCore.Mvc;

namespace AsuManagement.OrdersCrud.Presenters.Orders
{
    public class EditOrderPresenter : IResponsePresenter<EditOrderOutput>
    {
        public Task<IActionResult> Present(EditOrderOutput response)
        {
            return Task.FromResult(response.Succeeded
                ? (IActionResult)JsonActionResult.Ok(new { editedOrderId = response.EditedOrderId.Value })
                : JsonActionResult.BadRequest(response));
        }
    }
}
