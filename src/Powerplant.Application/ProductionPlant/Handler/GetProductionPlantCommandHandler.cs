using MediatR;
using Powerplant.Application.ProductionPlant.Commands;
using Powerplant.Domain.Interfaces;
using Powerplant.Domain.Notifications;
using Powerplant.Domain.Response;

namespace Powerplant.Application.ProductionPlant.Handler
{
    public class GetProductionPlantCommandHandler(IMediatorHandler mediator, IPowerPlantGenerationService powerPlantGenerationService) : IRequestHandler<GetProductionPlantCommand, List<ProductionPlantResponse>>
    {
        private readonly IMediatorHandler _mediator = mediator;
        private readonly IPowerPlantGenerationService _powerPlantGenerationService = powerPlantGenerationService;


        public Task<List<ProductionPlantResponse>> Handle(GetProductionPlantCommand request, CancellationToken cancellationToken)
        {
            var validations = request.GetErrors();
            if (validations.Count != 0)
            {
                foreach (var error in validations)
                {
                    _mediator.RaiseEvent(new DomainNotification(error.Key, error.Value));
                }
                return Task.FromResult(new List<ProductionPlantResponse>());
            }

            return Task.FromResult(_powerPlantGenerationService.GenerateProductionPlan(request.Request));
        }
    }
}
