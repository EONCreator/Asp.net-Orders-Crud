using AsuManagement.OrdersCrud.Helpers;
using Microsoft.AspNetCore.Mvc;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;

namespace AsuManagement.OrdersCrud.Presenters.Common
{
    public class EntityIdPresenter : IResponsePresenter<EntityIdOutput>
    {
        public Task<IActionResult> Present(EntityIdOutput response)
        {
            return Task.FromResult(response.Succeeded
                ? (IActionResult)JsonActionResult.Ok(new { response.Id })
                : JsonActionResult.BadRequest(response));
        }
    }
}
