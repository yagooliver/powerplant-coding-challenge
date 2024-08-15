using System.Text.Json.Serialization;

namespace Powerplant.Domain.Requests
{
    public class PayloadRequest
    {
        [JsonPropertyName("load")]
        public decimal Load { get; set; }
        
        [JsonPropertyName("fuels")]
        public Fuel Fuel { get; set; }
        [JsonPropertyName("powerplants")]
        public List<PowerPlant> PowerPlants { get; set; }
    }
}
