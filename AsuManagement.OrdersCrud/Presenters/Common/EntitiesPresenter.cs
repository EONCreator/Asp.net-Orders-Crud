using AsuManagement.OrdersCrud.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace AsuManagement.OrdersCrud.Presenters.Common
{
    public class EntitiesPresenter<TEntity> : IResponsePresenter<List<TEntity>>
    {
        public Task<IActionResult> Present(List<TEntity> response) =>
            Task.FromResult<IActionResult>(JsonActionResult.Ok(response));
    }
}
