using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using WizardWorld.Application.Requests.Houses;
using WizardWorldApi.Tests.Integrations.Extensions;
using WizardWorldApi.Tests.Shared;

namespace WizardWorldApi.Tests.Integrations.Tests {
    class HouseControllerTests {
        private HttpClient _client;

        [OneTimeSetUp]
        public void Setup() {
            var factory = new WizardWorldWebApplicationFactory();
            _client = factory.CreateClient();
        }

        [OneTimeTearDown]
        public void CleanUp() {
            _client.Dispose();
        }

        [Test]
        public async Task GetById_ShouldReturnHouse() {
            // Arrange
            var expectedHouse = HousesGenerator.Houses.First();
            // Act 
            var response = await _client.GetAsync($"Houses/{expectedHouse.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var house = await response.Content.DeserializeAsync<HouseDto>();

            // Assert
            house.Should().BeEquivalentTo(expectedHouse,
            config => config.Excluding(o => o.Heads)
                            .Excluding(o => o.Traits));
            house.Heads.Should().BeEquivalentTo(expectedHouse.Heads, o => o.Excluding(s => s.HouseId));
            house.Traits.Should().BeEquivalentTo(expectedHouse.Traits, o => o.Excluding(s => s.HouseId));

        }

        [Test]
        public async Task Get_ShouldReturnHousesList() {
            // Arrange
            var expectedHouses = HousesGenerator.Houses;
            // Act 
            var response = await _client.GetAsync("Houses");
            var content = response.Content.ReadAsStringAsync().Result;

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var houses = await response.Content.DeserializeAsync<List<HouseDto>>();

            // Assert
            houses.Should().NotBeEmpty();
            houses.Should().BeEquivalentTo(expectedHouses);
        }

        [Test]
        public async Task GetById_NotExistingId_ShouldReturnNotFound() {
            // Arrange
            var notExistingId = Guid.NewGuid();
            // Act 
            var response = await _client.GetAsync($"Houses/{notExistingId}");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
