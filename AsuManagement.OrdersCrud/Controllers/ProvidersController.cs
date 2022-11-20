using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AsuManagement.OrdersCrud.Domain.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AsuManagement.OrdersCrud.Domain.Interfaces.Results;
using AsuManagement.OrdersCrud.Interaction;

namespace AsuManagement.OrdersCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IInteractionBus _interactionBus;

        public ProvidersController(IInteractionBus interactionBus)
        {
            _interactionBus = interactionBus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await _interactionBus.Send(new GetProvidersCommand());
        }
    }
}
