using FluentValidation;
using Powerplant.Domain.Requests;

namespace Powerplant.Domain.Validators
{
    public class PayloadRequestValidator : AbstractValidator<PayloadRequest>
    {
        public PayloadRequestValidator()
        {
            RuleFor(x => x.Load)
                .GreaterThan(0).WithMessage("Load must be greater than 0.");

            RuleFor(x => x.Fuel)
                .NotNull().WithMessage("Fuel information is required.")
                .SetValidator(new FuelValidator());

            RuleFor(x => x.PowerPlants)
                .NotEmpty().WithMessage("At least one power plant is required.")
                .ForEach(plant => plant.SetValidator(new PowerPlantValidator()));
        }
    }
}
