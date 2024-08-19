using System.Text.Json.Serialization;

namespace Powerplant.Domain.Requests
{
    public class Fuel
    {
        [JsonPropertyName("gas(euro/MWh)")]
        public decimal GasEuroPerMWh { get; set; }
        [JsonPropertyName("kerosine(euro/MWh)")]
        public decimal KerosineEuroPerMWh { get; set; }
        [JsonPropertyName("co2(euro/ton)")]
        public decimal Co2EuroPerTon { get; set; }

        [JsonPropertyName("wind(%)")]
        public decimal WindPercentage { get; set; }
    }
}
