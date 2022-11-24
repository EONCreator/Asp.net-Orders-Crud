using AsuManagement.OrdersCrud.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace AsuManagement.OrdersCrud.Presenters.Common
{
    public class EntityPresenter<TEntity> : IResponsePresenter<TEntity>
    {
        public Task<IActionResult> Present(TEntity entity)
        {
            if (entity == null)
                return Task.FromResult<IActionResult>(JsonActionResult.NotFound());

            return Task.FromResult<IActionResult>(JsonActionResult.Ok(entity));
        }
    }
}
