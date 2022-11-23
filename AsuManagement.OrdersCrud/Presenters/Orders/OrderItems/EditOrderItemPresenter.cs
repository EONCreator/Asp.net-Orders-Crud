using AsuManagement.OrdersCrud.Helpers;
using AsuManagement.OrdersCrud.Services.Commands.Orders.EditOrderItem;
using Microsoft.AspNetCore.Mvc;

namespace AsuManagement.OrdersCrud.Presenters.Orders
{
    public class EditOrderItemPresenter : IResponsePresenter<EditOrderItemOutput>
    {
        public Task<IActionResult> Present(EditOrderItemOutput response)
        {
            return Task.FromResult(response.Succeeded
                ? (IActionResult)JsonActionResult.Ok(new { editedOrderId = response.EditedOrderItemId.Value })
                : JsonActionResult.BadRequest(response));
        }
    }
}
