using AsuManagement.OrdersCrud.Helpers;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using Microsoft.AspNetCore.Mvc;

namespace AsuManagement.OrdersCrud.Presenters
{
    public class QueryResponsesPresenter<TViewModel> : 
        IResponsePresenter<GetManyQueryResponse<TViewModel>>,
        IResponsePresenter<GetOneQueryResponse<TViewModel>>
        where TViewModel : class
    {
        public Task<IActionResult> Present(GetOneQueryResponse<TViewModel> response)
        {
            var result = response.Result;
            if (result == null)
                return Task.FromResult<IActionResult>(JsonActionResult.NotFound());

            return Task.FromResult<IActionResult>(JsonActionResult.Ok(result));
        }

        public Task<IActionResult> Present(GetManyQueryResponse<TViewModel> response) =>
            Task.FromResult<IActionResult>(JsonActionResult.Ok(response));
    }
}
