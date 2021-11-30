using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using WizardWorld.Application.Requests.Spells;
using WizardWorldApi.Tests.Integrations.Extensions;
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
        public async Task Get_NoQueryParameters_ShouldReturnSpellsList() {
            // Arrange
            var expectedSpells = SpellsGenerator.Spells;
            // Act 
            var response = await _client.GetAsync("Spell");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spells = await response.Content.DeserializeAsync<List<SpellDto>>();
            // Assert
            spells.Should().NotBeEmpty();
            spells.Should().BeEquivalentTo(expectedSpells);
        }

        [Test]
        public async Task Get_Name_ShouldReturnSpellsList() {
            // Arrange
            var expectedSpells = SpellsGenerator.Spells;
            var expectedSpell = expectedSpells.First();
            var query = new Dictionary<string, string> {
                ["Name"] = expectedSpell.Name
            };
            // Act 
            var response = await _client.GetAsync($"Spell", query);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spells = await response.Content.DeserializeAsync<List<SpellDto>>();
            // Assert
            spells.Should().NotBeEmpty();
            expectedSpells.Where(a => a.Name.StartsWith(expectedSpell.Name))
                .Should().ContainEquivalentOf(expectedSpell);
        }

        [Test]
        public async Task Get_Incantation_ShouldReturnSpellsList() {
            // Arrange
            var expectedSpells = SpellsGenerator.Spells;
            var expectedSpell = expectedSpells.First();
            var query = new Dictionary<string, string> {
                ["Incantation"] = expectedSpell.Incantation
            };
            // Act 
            var response = await _client.GetAsync($"Spell", query);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spells = await response.Content.DeserializeAsync<List<SpellDto>>();
            // Assert
            spells.Should().NotBeEmpty();
            expectedSpells.Where(a => a.Incantation.StartsWith(expectedSpell.Incantation))
                .Should().ContainEquivalentOf(expectedSpell);
        }

        [Test]
        public async Task Get_SpellType_ShouldReturnSpellsList() {
            // Arrange
            var expectedSpells = SpellsGenerator.Spells;
            var expectedSpell = expectedSpells.First();
            var query = new Dictionary<string, string> {
                ["Type"] = expectedSpell.Type.ToString(),
            };
            // Act 
            var response = await _client.GetAsync($"Spell", query);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spells = await response.Content.DeserializeAsync<List<SpellDto>>();
            // Assert
            spells.Should().NotBeEmpty();
            expectedSpells.Where(a => a.Type == expectedSpell.Type).Should().ContainEquivalentOf(expectedSpell);
        }

        [Test]
        public async Task Get_NameAndType_ShouldReturnSpellsList() {
            // Arrange
            var expectedSpells = SpellsGenerator.Spells;
            var expectedSpell = expectedSpells.First();
            var query = new Dictionary<string, string> {
                ["Name"] = expectedSpell.Name,
                ["Type"] = expectedSpell.Type.ToString()
            };
            // Act 
            var response = await _client.GetAsync($"Spell", query);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spells = await response.Content.DeserializeAsync<List<SpellDto>>();
            // Assert
            spells.Should().NotBeEmpty();
            expectedSpells.Where(a => a.Name.StartsWith(expectedSpell.Name)
                                      && a.Type == expectedSpell.Type).Should().ContainEquivalentOf(expectedSpell);
        }

        [Test]
        public async Task Get_NameAndIncantation_ShouldReturnSpellsList() {
            // Arrange
            var expectedSpells = SpellsGenerator.Spells;
            var expectedSpell = expectedSpells.First();
            var query = new Dictionary<string, string> {
                ["Name"] = expectedSpell.Name,
                ["Incantation"] = expectedSpell.Incantation
            };
            // Act 
            var response = await _client.GetAsync($"Spell", query);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spells = await response.Content.DeserializeAsync<List<SpellDto>>();
            // Assert
            spells.Should().NotBeEmpty();
            expectedSpells.Where(a => a.Name.StartsWith(expectedSpell.Name)
                                       && a.Incantation.StartsWith(expectedSpell.Incantation))
                                           .Should().ContainEquivalentOf(expectedSpell);
        }

        [Test]
        public async Task Get_TypeAndIncantation_ShouldReturnSpellsList() {
            // Arrange
            var expectedSpells = SpellsGenerator.Spells;
            var expectedSpell = expectedSpells.First();
            var query = new Dictionary<string, string> {
                ["Type"] = expectedSpell.Type.ToString(),
                ["Incantation"] = expectedSpell.Incantation
            };
            // Act 
            var response = await _client.GetAsync("Spell", query);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spells = await response.Content.DeserializeAsync<List<SpellDto>>();
            // Assert
            spells.Should().NotBeEmpty();
            expectedSpells.Where(a => a.Incantation.StartsWith(expectedSpell.Incantation)
                                      && a.Type == expectedSpell.Type).Should().ContainEquivalentOf(expectedSpell);
        }

        [Test]
        public async Task Get_NameAndTypeAndIncantation_ShouldReturnSpellsList() {
            // Arrange
            var expectedSpells = SpellsGenerator.Spells;
            var expectedSpell = expectedSpells.First();
            var query = new Dictionary<string, string> {
                ["Name"] = expectedSpell.Name,
                ["Type"] = expectedSpell.Type.ToString(),
                ["Incantation"] = expectedSpell.Incantation
            };
            // Act 
            var response = await _client.GetAsync("Spell", query);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spells = await response.Content.DeserializeAsync<List<SpellDto>>();
            // Assert
            spells.Should().NotBeEmpty();
            expectedSpells.Where(a => a.Name.StartsWith(expectedSpell.Name)
                                      && a.Incantation.StartsWith(expectedSpell.Incantation)
                                      && a.Type == expectedSpell.Type).Should().ContainEquivalentOf(expectedSpell);
        }

        [Test]
        public async Task GetById_ShouldReturnSpell() {
            // Arrange
            var expectedSpell = SpellsGenerator.Spells.First();
            // Act 
            var response = await _client.GetAsync($"Spell/{expectedSpell.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spell = await response.Content.DeserializeAsync<SpellDto>();
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