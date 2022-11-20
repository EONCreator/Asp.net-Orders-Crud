using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using AsuManagement.OrdersCrud.Helpers;
using AsuManagement.OrdersCrud.Presenters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AsuManagement.OrdersCrud.Interaction
{
    public interface IInteractionBus
    {
        Task<IActionResult> Send<TResponse>(IRequest<TResponse> request);
    }

    public class InteractionBus : IInteractionBus
    {
        private readonly IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;

        public InteractionBus(IMediator mediator, IServiceProvider serviceProvider)
        {
            _mediator = mediator;
            _serviceProvider = serviceProvider;
        }

        public async Task<IActionResult> Send<TResponse>(IRequest<TResponse> request)
        {
            var response = await _mediator.Send(request);
            var presenter = _serviceProvider.GetService<IResponsePresenter<TResponse>>();
            if (presenter != null)
                return await presenter.Present(response);

            return PresentDefault(response);
        }

        private IActionResult PresentDefault<TResponse>(TResponse response)
        {
            if (response == null)
                throw new ArgumentNullException("empty response", nameof(response));

            var responseType = response.GetType();
            // todo: I think the difference between SucceededResult and generic SucceededResult<> needs to be fixed on the server side.
            // Because this is strange behavior and because otherwise you have to write extra code, like SucceededResultWithData or many others inheritance from SucceededResult
            if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typeof(SucceededResult<>))
            {
                dynamic d = response;
                return d.Succeeded ? JsonActionResult.Ok(d.Result) : JsonActionResult.BadRequest(new { d.Errors });
            }

            if (response.GetType() == typeof(SucceededResult))
            {
                var succeededResult = response as SucceededResult;
                return succeededResult!.Succeeded
                    ? JsonActionResult.Ok(response)
                    : JsonActionResult.BadRequest(response);
            }

            return JsonActionResult.Ok(response);
        }
    }
}
