
using System.Text.Json.Serialization;

namespace Powerplant.Domain.Response
{
    public class ProductionPlantResponse(string name, decimal p)
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = name;
        [JsonPropertyName("p")]
        public decimal P { get; set; } = p;
    }
}
