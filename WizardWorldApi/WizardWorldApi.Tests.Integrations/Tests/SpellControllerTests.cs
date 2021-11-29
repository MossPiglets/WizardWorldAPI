using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
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
            // Act 
            var response = await _client.GetAsync($"Spell?Name={expectedSpell.Name}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spells = await response.Content.DeserializeAsync<List<SpellDto>>();
            // Assert
            spells.Should().NotBeEmpty();
            spells[0].Should().BeEquivalentTo(expectedSpell);
        }
        
        [Test]
        public async Task Get_Incantation_ShouldReturnSpellsList() {
            // Arrange
            var expectedSpells = SpellsGenerator.Spells;
            var expectedSpell = expectedSpells.First();
            // Act 
            var response = await _client.GetAsync($"Spell?Incantation={expectedSpell.Incantation}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spells = await response.Content.DeserializeAsync<List<SpellDto>>();
            // Assert
            spells.Should().NotBeEmpty();
            spells[0].Should().BeEquivalentTo(expectedSpell);
        }
        
        [Test]
        public async Task Get_SpellType_ShouldReturnSpellsList() {
            // Arrange
            var expectedSpells = SpellsGenerator.Spells;
            var expectedSpell = expectedSpells.First();
            // Act 
            var response = await _client.GetAsync($"Spell?Type={expectedSpell.Type}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spells = await response.Content.DeserializeAsync<List<SpellDto>>();
            // Assert
            spells.Should().NotBeEmpty();
            spells[0].Should().BeEquivalentTo(expectedSpell);
        }
        
        [Test]
        public async Task Get_NameAndType_ShouldReturnSpellsList() {
            // Arrange
            var expectedSpells = SpellsGenerator.Spells;
            var expectedSpell = expectedSpells.First();
            // Act 
            var response = await _client.GetAsync($"Spell?Name={expectedSpell.Name}&Type={expectedSpell.Type}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spells = await response.Content.DeserializeAsync<List<SpellDto>>();
            // Assert
            spells.Should().NotBeEmpty();
            spells[0].Should().BeEquivalentTo(expectedSpell);
        }
        
        [Test]
        public async Task Get_NameAndIncantation_ShouldReturnSpellsList() {
            // Arrange
            var expectedSpells = SpellsGenerator.Spells;
            var expectedSpell = expectedSpells.First();
            // Act 
            var response = await _client.GetAsync($"Spell?Name={expectedSpell.Name}&Incantation={expectedSpell.Incantation}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spells = await response.Content.DeserializeAsync<List<SpellDto>>();
            // Assert
            spells.Should().NotBeEmpty();
            spells[0].Should().BeEquivalentTo(expectedSpell);
        }
        
        [Test]
        public async Task Get_TypeAndIncantation_ShouldReturnSpellsList() {
            // Arrange
            var expectedSpells = SpellsGenerator.Spells;
            var expectedSpell = expectedSpells.First();
            // Act 
            var response = await _client.GetAsync($"Spell?Type={expectedSpell.Type}&Incantation={expectedSpell.Incantation}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spells = await response.Content.DeserializeAsync<List<SpellDto>>();
            // Assert
            spells.Should().NotBeEmpty();
            spells[0].Should().BeEquivalentTo(expectedSpell);
        }
        
        [Test]
        public async Task Get_NameAndTypeAndIncantation_ShouldReturnSpellsList() {
            // Arrange
            var expectedSpells = SpellsGenerator.Spells;
            var expectedSpell = expectedSpells.First();
            // Act 
            var response = await _client
                .GetAsync($"Spell?Name={expectedSpell.Name}&Type={expectedSpell.Type}&Incantation={expectedSpell.Incantation}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var spells = await response.Content.DeserializeAsync<List<SpellDto>>();
            // Assert
            spells.Should().NotBeEmpty();
            spells[0].Should().BeEquivalentTo(expectedSpell);
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