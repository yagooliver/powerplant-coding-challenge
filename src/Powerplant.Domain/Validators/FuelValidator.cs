using FluentValidation;
using Powerplant.Domain.Requests;

namespace Powerplant.Domain.Validators
{
    public class FuelValidator : AbstractValidator<Fuel>
    {
        public FuelValidator()
        {
            RuleFor(x => x.GasEuroPerMWh)
                .GreaterThan(0).WithMessage("Gas price per MWh must be greater than 0.");

            RuleFor(x => x.KerosineEuroPerMWh)
                .GreaterThan(0).WithMessage("Kerosine price per MWh must be greater than 0.");

            RuleFor(x => x.Co2EuroPerTon)
                .GreaterThanOrEqualTo(0).WithMessage("CO2 price per ton must be non-negative.");

            RuleFor(x => x.WindPercentage)
                .InclusiveBetween(0, 100).WithMessage("Wind percentage must be between 0 and 100.");
        }
    }
}
