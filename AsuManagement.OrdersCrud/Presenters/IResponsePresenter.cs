using Microsoft.AspNetCore.Mvc;

namespace AsuManagement.OrdersCrud.Presenters
{
    public interface IResponsePresenter<TResponse>
    {
        Task<IActionResult> Present(TResponse response);
    }
}
