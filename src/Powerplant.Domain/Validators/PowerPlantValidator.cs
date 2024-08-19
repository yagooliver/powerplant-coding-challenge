using FluentValidation;
using Powerplant.Domain.Requests;

namespace Powerplant.Domain.Validators
{
    public class PowerPlantValidator : AbstractValidator<PowerPlant>
    {
        public PowerPlantValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Power plant name is required.");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Power plant type is required.")
                .Must(type => type == "gasfired" || type == "turbojet" || type == "windturbine")
                .WithMessage("Power plant type must be 'gasfired', 'turbojet', or 'windturbine'.");

            RuleFor(x => x.Efficiency)
                .InclusiveBetween(0.01m, 1m).WithMessage("Efficiency must be between 0.01 and 1.");

            RuleFor(x => x.Pmin)
                .GreaterThanOrEqualTo(0).WithMessage("Pmin must be non-negative.");

            RuleFor(x => x.Pmax)
                .GreaterThan(0).WithMessage("Pmax must be greater than 0.")
                .GreaterThanOrEqualTo(x => x.Pmin)
                .WithMessage("Pmax must be greater than or equal to Pmin.");
        }
    }
}
