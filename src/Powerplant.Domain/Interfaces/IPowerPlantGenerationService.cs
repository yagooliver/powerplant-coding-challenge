using Powerplant.Domain.Requests;
using Powerplant.Domain.Response;

namespace Powerplant.Domain.Interfaces
{
    public interface IPowerPlantGenerationService
    {
        List<ProductionPlantResponse> GenerateProductionPlan(PayloadRequest payload);
    }
}
