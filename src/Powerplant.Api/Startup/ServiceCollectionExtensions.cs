using MediatR;
using Powerplant.Application.Mediator;
using Powerplant.Application.ProductionPlant.Commands;
using Powerplant.Application.ProductionPlant.Handler;
using Powerplant.Application.Service;
using Powerplant.Domain.Interfaces;
using Powerplant.Domain.Notifications;
using Powerplant.Domain.Response;

namespace Powerplant.Api.Startup
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPowerPlantGenerationService, PowerPlantGenerationService>();
        }
        public static void AddCommands(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IRequestHandler<GetProductionPlantCommand, List<ProductionPlantResponse>>, GetProductionPlantCommandHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }
    }
}
