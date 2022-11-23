using Microsoft.AspNetCore.Mvc;
using AsuManagement.OrdersCrud.Interaction;
using AsuManagement.OrdersCrud.Services.Commands.Providers;

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
        public async Task<IActionResult> Get([FromQuery(Name = "numbers")] string? numbers)
        {
            return await _interactionBus.Send(new GetProvidersCommand(numbers));
        }
    }
}
