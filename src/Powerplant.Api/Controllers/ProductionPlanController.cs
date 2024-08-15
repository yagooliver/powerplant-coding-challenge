using MediatR;
using Microsoft.AspNetCore.Mvc;
using Powerplant.Application.ProductionPlant.Commands;
using Powerplant.Domain.Interfaces;
using Powerplant.Domain.Notifications;
using Powerplant.Domain.Requests;
using Powerplant.Domain.Response;

namespace Powerplant.Api.Controllers
{
    [Route("productionplan")]
    [Produces("application/json")]
    public class ProductionPlanController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediatorHandler) : ApiControllerBase(notifications, mediatorHandler)
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductionPlantResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] PayloadRequest request)
        {
            return Response(await _mediator.Send(new GetProductionPlantCommand(request)));
        }
    }
}
