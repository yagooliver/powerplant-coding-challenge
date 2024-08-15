using Microsoft.AspNetCore.Mvc.Testing;
using Powerplant.Domain.Response;
using System.Net.Http.Json;
using System.Text;

namespace Powerplant.Tests.IntegrationTests
{
    public class PowerplantIntegrationTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client = factory.CreateClient();

        [Fact]
        public async Task Post_Powerplan_request_should_return_200()
        {
            //Arrange
            var content = new StringContent(GetPayload(), Encoding.UTF8, "application/json");
            // Act: Send the payload to the API and get the response
            var response = await _client.PostAsync("/productionplan", content);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<List<ProductionPlantResponse>>();

            // Assert: Verify the response matches the expected output
            var expectedResponse = new List<ProductionPlantResponse>
            {
                new("windpark1", 90.0m),
                new("windpark2", 21.6m),
                new("gasfiredbig1",460.0m),
                new("gasfiredbig2",338.4m),
                new("gasfiredsomewhatsmaller", 0.0m),
                new("tj1",0.0m)
            };

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expectedResponse.Count, result.Count);
            for (int i = 0; i < expectedResponse.Count; i++)
            {
                Assert.Equal(expectedResponse[i].Name, result[i].Name);
                Assert.Equal(expectedResponse[i].P, result[i].P);
            }
        }

        [Fact]
        public async Task Post_Powerplan_request_should_return_400_bad_request()
        {
            //Arrange
            var content = new StringContent(GetBadPayloadRequest(), Encoding.UTF8, "application/json");
            // Act: Send the payload to the API and get the response
            var response = await _client.PostAsync("/productionplan", content);
            var result = await response.Content.ReadAsStringAsync();

            // Assert: Verify the response matches the expected output

            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Contains("\"Power plant name is required.\"", result);
        }

        private static string GetBadPayloadRequest()
        {
            return @"
            {
              ""load"": 910,
              ""fuels"": {
                ""gas(euro/MWh)"": 13.4,
                ""kerosine(euro/MWh)"": 50.8,
                ""co2(euro/ton)"": 20,
                ""wind(%)"": 60
              },
              ""powerplants"": [
                {
                  ""name"": null,
                  ""type"": ""gasfired"",
                  ""efficiency"": 0.53,
                  ""pmin"": 100,
                  ""pmax"": 460
                }
              ]
            }";
        }

        private static string GetPayload()
        {
            return @"
            {
              ""load"": 910,
              ""fuels"": {
                ""gas(euro/MWh)"": 13.4,
                ""kerosine(euro/MWh)"": 50.8,
                ""co2(euro/ton)"": 20,
                ""wind(%)"": 60
              },
              ""powerplants"": [
                {
                  ""name"": ""gasfiredbig1"",
                  ""type"": ""gasfired"",
                  ""efficiency"": 0.53,
                  ""pmin"": 100,
                  ""pmax"": 460
                },
                {
                  ""name"": ""gasfiredbig2"",
                  ""type"": ""gasfired"",
                  ""efficiency"": 0.53,
                  ""pmin"": 100,
                  ""pmax"": 460
                },
                {
                  ""name"": ""gasfiredsomewhatsmaller"",
                  ""type"": ""gasfired"",
                  ""efficiency"": 0.37,
                  ""pmin"": 40,
                  ""pmax"": 210
                },
                {
                  ""name"": ""tj1"",
                  ""type"": ""turbojet"",
                  ""efficiency"": 0.3,
                  ""pmin"": 0,
                  ""pmax"": 16
                },
                {
                  ""name"": ""windpark1"",
                  ""type"": ""windturbine"",
                  ""efficiency"": 1,
                  ""pmin"": 0,
                  ""pmax"": 150
                },
                {
                  ""name"": ""windpark2"",
                  ""type"": ""windturbine"",
                  ""efficiency"": 1,
                  ""pmin"": 0,
                  ""pmax"": 36
                }
              ]
            }";
        }
    }
}
