using FluentValidation;
using Powerplant.Application.ProductionPlant.Commands;
using Powerplant.Domain.Validators;

namespace Powerplant.Application.ProductionPlant.Validator
{
    public class GetProductionPlantCommandValidator : AbstractValidator<GetProductionPlantCommand>
    {
        public GetProductionPlantCommandValidator()
        {
            RuleFor(x => x.Request).NotNull().WithMessage("Request cannot be null.");
            RuleFor(x => x.Request).SetValidator(new PayloadRequestValidator());
        }
    }
}
