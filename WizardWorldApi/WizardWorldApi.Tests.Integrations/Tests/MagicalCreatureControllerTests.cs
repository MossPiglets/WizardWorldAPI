using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WizardWorld.Application.Requests.MagicalCreatures;
using WizardWorldApi.Tests.Integrations.Extensions;
using WizardWorldApi.Tests.Shared;

namespace WizardWorldApi.Tests.Integrations.Tests {
    class MagicalCreatureControllerTests {
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
        public async Task Get_ShouldReturnMagicalCreaturesList() {
            // Arrange
            var expectedCreatures = MagicalCreaturesGenerator.MagicalCreatures;
            // Act 
            var response = await _client.GetAsync("MagicalCreature");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var magicalCreatures = await response.Content.DeserializeAsync<List<MagicalCreatureDto>>();
            // Assert
            magicalCreatures.Should().NotBeEmpty();
            magicalCreatures.Should().BeEquivalentTo(expectedCreatures, o=>o.ExcludingMissingMembers());
        }

        [Test]
        public async Task GetById_ShouldReturnMagicalCreaturesList() {
            // Arrange
            var expectedCreature = MagicalCreaturesGenerator.MagicalCreatures.First();
            // Act 
            var response = await _client.GetAsync($"MagicalCreature/{expectedCreature.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spell = await response.Content.DeserializeAsync<MagicalCreatureDto>();
            // Assert
            spell.Should().BeEquivalentTo(expectedCreature, o=>o.ExcludingMissingMembers());
        }

        [Test]
        public async Task GetById_NotExistingId_ShouldReturnNotFound() {
            // Arrange
            var notExistingId = Guid.NewGuid();
            // Act 
            var response = await _client.GetAsync($"MagicalCreature/{notExistingId}");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
