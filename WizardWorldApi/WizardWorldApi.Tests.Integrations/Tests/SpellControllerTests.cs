using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using WizardWorld.Application.Requests.Spells;
using WizardWorldApi.Tests.Integrations.Generators;

namespace WizardWorldApi.Tests.Integrations.Tests {
    public class SpellControllerTests {
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
        public async Task Get_ShouldReturnSpellsList() {
            // Arrange
            var expectedSpells = SpellsGenerator.Spells;
            // Act 
            var response = await _client.GetAsync("Spell");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spells = await response.Content.ReadFromJsonAsync<List<SpellDto>>();
            // Assert
            spells.Should().NotBeEmpty();
            spells.Should().BeEquivalentTo(expectedSpells);
        }
        [Test]
        public async Task GetById_ShouldReturnSpell() {
            // Arrange
            var expectedSpell = SpellsGenerator.Spells.First();
            // Act 
            var response = await _client.GetAsync($"Spell/{expectedSpell.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spell = await response.Content.ReadFromJsonAsync<SpellDto>();
            // Assert
            spell.Should().BeEquivalentTo(expectedSpell);
        }
        [Test]
        public async Task GetById_NotExistingId_ShouldReturnNotFound() {
            // Arrange
            var notExistingId = Guid.NewGuid();
            // Act 
            var response = await _client.GetAsync($"Spell/{notExistingId}");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}