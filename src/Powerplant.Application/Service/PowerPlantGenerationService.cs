using Powerplant.Domain.Enum;
using Powerplant.Domain.Interfaces;
using Powerplant.Domain.Requests;
using Powerplant.Domain.Response;

namespace Powerplant.Application.Service
{
    public class PowerPlantGenerationService : IPowerPlantGenerationService
    {
        public List<ProductionPlantResponse> GenerateProductionPlan(PayloadRequest payload)
        {
            decimal remainingLoad = payload.Load;
            var productionPlan = new List<ProductionPlantResponse>();

            foreach (var plant in payload.PowerPlants.Where(p => p.Type.Equals(nameof(PowerPlantType.windturbine), StringComparison.InvariantCultureIgnoreCase)))
            {
                decimal powerProduced = CalculateWindPower(plant, payload.Fuel);
                remainingLoad -= powerProduced;
                productionPlan.Add(new ProductionPlantResponse(plant.Name, powerProduced));
            }

            var otherPlants = payload.PowerPlants
                .Where(p => !p.Type.Equals(nameof(PowerPlantType.windturbine), StringComparison.InvariantCultureIgnoreCase))
                .Select(plant => new
                {
                    Plant = plant,
                    MarginalCost = plant.Type.Equals(nameof(PowerPlantType.gasfired), StringComparison.InvariantCultureIgnoreCase)
                        ? payload.Fuel.GasEuroPerMWh / plant.Efficiency
                        : payload.Fuel.KerosineEuroPerMWh / plant.Efficiency
                })
                .OrderBy(p => p.MarginalCost)
                .ToList();

            foreach (var item in otherPlants)
            {
                decimal powerProduced = 0;

                switch (item.Plant.Type)
                {
                    case nameof(PowerPlantType.gasfired):
                        powerProduced = CalculateGasFiredPower(item.Plant, ref remainingLoad);
                        break;
                    case nameof(PowerPlantType.turbojet):
                        powerProduced = CalculateTurbojetPower(item.Plant, ref remainingLoad);
                        break;
                }

                productionPlan.Add(new ProductionPlantResponse(item.Plant.Name, powerProduced));
            }

            return productionPlan;
        }

        private static decimal CalculateWindPower(PowerPlant plant, Fuel fuel)
        {
            return plant.Pmax * (fuel.WindPercentage / 100);
        }

        private static decimal CalculateGasFiredPower(PowerPlant plant, ref decimal remainingLoad)
        {
            decimal powerToGenerate = Math.Min(remainingLoad, plant.Pmax);
            if (powerToGenerate >= plant.Pmin)
            {
                remainingLoad -= powerToGenerate;
            }
            else
            {
                powerToGenerate = 0;
            }

            return powerToGenerate;
        }

        private static decimal CalculateTurbojetPower(PowerPlant plant, ref decimal remainingLoad)
        {
            decimal powerToGenerate = Math.Min(remainingLoad, plant.Pmax);
            remainingLoad -= powerToGenerate;
            return powerToGenerate;
        }
    }
}
