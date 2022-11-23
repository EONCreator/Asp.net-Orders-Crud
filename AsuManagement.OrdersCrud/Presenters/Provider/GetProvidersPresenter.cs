using AsuManagement.OrdersCrud.Helpers;
using AsuManagement.OrdersCrud.Services.Commands.Providers;
using Microsoft.AspNetCore.Mvc;

namespace AsuManagement.OrdersCrud.Presenters.Providers
{
    public class GetProvidersPresenter : IResponsePresenter<GetProvidersOutput>
    {
        public Task<IActionResult> Present(GetProvidersOutput response) =>
            Task.FromResult<IActionResult>(JsonActionResult.Ok(response));
    }
}
