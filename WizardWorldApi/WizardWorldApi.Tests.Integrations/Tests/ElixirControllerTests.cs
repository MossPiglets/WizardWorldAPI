using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using WizardWorld.Application.Requests.Elixirs;
using WizardWorldApi.Tests.Integrations.Extensions;
using WizardWorldApi.Tests.Integrations.Generators;

namespace WizardWorldApi.Tests.Integrations.Tests {
    public class ElixirControllerTests {
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
        public async Task GetById_ShouldReturnElixir() {
            // Arrange
            var expectedElixir = ElixirsGenerator.Elixirs.First();
            // Act 
            var response = await _client.GetAsync($"Elixirs/{expectedElixir.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var elixir = await response.Content.DeserializeAsync<ElixirDto>();
            // Assert
            elixir.Should().BeEquivalentTo(expectedElixir,
                o => o.Excluding(i => i.Ingredients)
                    .Excluding(i => i.Inventors));
        }

        [Test]
        public async Task GetById_NotExistingId_ShouldReturnNotFound() {
            // Arrange
            var notExistingId = Guid.NewGuid();
            // Act 
            var response = await _client.GetAsync($"Elixirs/{notExistingId}");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        
        [Test]
        public async Task Get_NoQueryParameters_ShouldReturnElixirsList() {
            // Arrange
            var expectedElixirs = ElixirsGenerator.Elixirs;
            // Act 
            var response = await _client.GetAsync("Elixirs");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var elixirs = await response.Content.DeserializeAsync<List<ElixirDto>>();
            // Assert
            elixirs.Should().NotBeEmpty();
            elixirs.Should().BeEquivalentTo(expectedElixirs, 
                o => o.Excluding(i => i.Ingredients)
                    .Excluding(i => i.Inventors));
        }

        [Test]
        public async Task Get_Name_ShouldReturnElixirsList() {
            // Arrange
            var expectedElixirs = ElixirsGenerator.Elixirs;
            var expectedElixir = expectedElixirs.First();
            var query = new Dictionary<string, string> {
                ["Name"] = expectedElixir.Name
            };
            // Act 
            var response = await _client.GetAsync($"Elixirs", query);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var elixirs = await response.Content.DeserializeAsync<List<ElixirDto>>();
            // Assert
            elixirs.Should().NotBeEmpty();
            expectedElixirs.Where(a => a.Name.StartsWith(expectedElixir.Name))
                .Should().ContainEquivalentOf(expectedElixir);
        }
        
        [Test]
        public async Task Get_Difficulty_ShouldReturnElixirsList() {
            // Arrange
            var expectedElixirs = ElixirsGenerator.Elixirs;
            var expectedElixir = expectedElixirs.First();
            var query = new Dictionary<string, string> {
                ["Difficulty"] = expectedElixir.Difficulty.ToString()
            };
            // Act 
            var response = await _client.GetAsync($"Elixirs", query);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var elixirs = await response.Content.DeserializeAsync<List<ElixirDto>>();
            // Assert
            elixirs.Should().NotBeEmpty();
            expectedElixirs.Where(a => a.Difficulty.ToString().StartsWith(expectedElixir.Difficulty.ToString()))
                .Should().ContainEquivalentOf(expectedElixir);
        }
        
        [Test]
        public async Task Get_Ingredient_ShouldReturnElixirsList() {
            // Arrange
            var expectedElixirs = ElixirsGenerator.Elixirs;
            var expectedElixir = expectedElixirs.First();
            var expectedIngredient = expectedElixir.Ingredients.First().Name;
            var query = new Dictionary<string, string> {
                ["Ingredient"] = expectedIngredient
            };
            // Act 
            var response = await _client.GetAsync($"Elixirs", query);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var elixirs = await response.Content.DeserializeAsync<List<ElixirDto>>();
            // Assert
            elixirs.Should().NotBeEmpty();
            expectedElixirs.Where(a => a.Ingredients.Any(a => a.Name.StartsWith(expectedIngredient)))
                .Should().ContainEquivalentOf(expectedElixir);
        }
        
        [Test]
        public async Task Get_Inventors_ShouldReturnElixirsList() {
            // Arrange
            var expectedElixirs = ElixirsGenerator.Elixirs;
            var expectedElixir = expectedElixirs.First();
            var expectedInventor = expectedElixir.Inventors.First();
            var expectedName = expectedInventor.FirstName + expectedInventor.LastName;
            var query = new Dictionary<string, string> {
                ["InventorFullName"] = expectedName
            };
            // Act 
            var response = await _client.GetAsync($"Elixirs", query);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var elixirs = await response.Content.DeserializeAsync<List<ElixirDto>>();
            // Assert
            elixirs.Should().NotBeEmpty();
            expectedElixirs.Where(a => a.Inventors
                    .Any(a => (expectedName.Contains(a.FirstName) || (expectedName.Contains(a.LastName)))))
                .Should().ContainEquivalentOf(expectedElixir);
        }
        
        [Test]
        public async Task Get_Manufacturer_ShouldReturnElixirsList() {
            // Arrange
            var expectedElixirs = ElixirsGenerator.Elixirs;
            var expectedElixir = expectedElixirs.First();
            var query = new Dictionary<string, string> {
                ["Manufacturer"] = expectedElixir.Manufacturer
            };
            // Act 
            var response = await _client.GetAsync($"Elixirs", query);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var elixirs = await response.Content.DeserializeAsync<List<ElixirDto>>();
            // Assert
            elixirs.Should().NotBeEmpty();
            expectedElixirs.Where(a => a.Manufacturer.StartsWith(expectedElixir.Manufacturer))
                .Should().ContainEquivalentOf(expectedElixir);
        }
        
        [Test]
        public async Task Get_NameDifficultyIngredientInventorManufacturer_ShouldReturnElixirsList() {
            // Arrange
            var expectedElixirs = ElixirsGenerator.Elixirs;
            var expectedElixir = expectedElixirs.First();
            var expectedInventor = expectedElixir.Inventors.First();
            var expectedIngredient = expectedElixir.Ingredients.First().Name;
            var expectedName = expectedInventor.FirstName + expectedInventor.LastName;
            var query = new Dictionary<string, string> {
                ["Name"] = expectedElixir.Name,
                ["Difficulty"] = expectedElixir.Difficulty.ToString(),
                ["Ingredient"] = expectedIngredient,
                ["InventorFullName"] = expectedName,
                ["Manufacturer"] = expectedElixir.Manufacturer
            };
            // Act 
            var response = await _client.GetAsync($"Elixirs", query);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var elixirs = await response.Content.DeserializeAsync<List<ElixirDto>>();
            // Assert
            elixirs.Should().NotBeEmpty();
            expectedElixirs.Where(a => (a.Name.StartsWith(expectedElixir.Name)
                                        && a.Difficulty.ToString().StartsWith(expectedElixir.Difficulty.ToString())
                                        && a.Ingredients.Any(a => a.Name.StartsWith(expectedIngredient))
                                        && a.Inventors
                    .Any(a => (expectedName.Contains(a.FirstName) || (expectedName.Contains(a.LastName)))))
                                        && a.Manufacturer.StartsWith(expectedElixir.Manufacturer))
                .Should().ContainEquivalentOf(expectedElixir);
        }
    }
}