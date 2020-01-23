using FareManagement.Calculator.Model;
using FareManagement.Web.Api.IntegrationTests.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Api.IntegrationTests;
using Xunit;

namespace FareManagement.Web.Api.IntegrationTests
{
    public class FareCalculatorControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly TripDetailDto tripDetailDto;
        private readonly HttpClient _client;

        public FareCalculatorControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            tripDetailDto = new TripDetailDto()
            {
                CityBasedSurchargeAmount = 0.5,
                LessThan6MilesPerHourSpeedRangeIndicator = 2,
                MoreThan6MilesPerHourOr60SecondsDurationIndicator = 5,
                TripDate = Convert.ToDateTime("01/17/2020 5:30pm")
            };
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CalculateFare_ShouldReturnCorrectAmount_When_Called()
        {
            double expectedResult = 9.75;
            var httpResponse = await _client.GetAsync(string.Concat("/api/v1/fair?", tripDetailDto.ToQueryString()));
            httpResponse.EnsureSuccessStatusCode();
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var rate = JsonConvert.DeserializeObject<double>(stringResponse);
            Assert.Equal(rate, expectedResult);
        }
    }
}
