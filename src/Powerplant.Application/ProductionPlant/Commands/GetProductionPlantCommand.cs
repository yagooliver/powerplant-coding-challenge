using Powerplant.Application.ProductionPlant.Validator;
using Powerplant.Domain.Commands;
using Powerplant.Domain.Requests;
using Powerplant.Domain.Response;

namespace Powerplant.Application.ProductionPlant.Commands
{
    public class GetProductionPlantCommand(PayloadRequest request) : CommandBase<List<ProductionPlantResponse>>
    {
        public PayloadRequest Request { get; } = request;
        public override Dictionary<string, string> GetErrors()
        {
            var validator = new GetProductionPlantCommandValidator();
            var validationResult = validator.Validate(this);

            if (validationResult.IsValid)
            {
                return [];
            }

            return validationResult.Errors.ToDictionary(x => x.PropertyName, x => x.ErrorMessage);
        }
    }
}
