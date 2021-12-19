using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using WizardWorld.Application.Requests.Ingredients;
using WizardWorldApi.Tests.Integrations.Extensions;
using WizardWorldApi.Tests.Shared;

namespace WizardWorldApi.Tests.Integrations.Tests {
    public class IngredientControllerTests {
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
        public async Task Get_NoQueryParameters_ShouldReturnIngredientsList() {
            // Arrange
            var expectedIngredients = IngredientsGenerator.Ingredients;
            // Act 
            var response = await _client.GetAsync("Ingredients");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var ingredients = await response.Content.DeserializeAsync<List<IngredientDto>>();
            // Assert
            ingredients.Should().NotBeEmpty();
            ingredients.Should()
                .BeEquivalentTo(expectedIngredients, o => o.Excluding(i => i.Elixirs));
        }

        [Test]
        public async Task Get_Name_ShouldReturnIngredientsList() {
            // Arrange
            var expectedIngredients = IngredientsGenerator.Ingredients;
            var expectedIngredient = expectedIngredients.First();
            var query = new Dictionary<string, string> {
                ["Name"] = expectedIngredient.Name
            };
            // Act 
            var response = await _client.GetAsync("Ingredients", query);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var ingredients = await response.Content.DeserializeAsync<List<IngredientDto>>();
            // Assert
            ingredients.Should().NotBeEmpty();
            ingredients.Where(a => a.Name.StartsWith(expectedIngredient.Name)).Should()
                .ContainEquivalentOf(expectedIngredient, o => o.Excluding(i => i.Elixirs));
        }

        [Test]
        public async Task GetById_ShouldReturnIngredient() {
            // Arrange
            var expectedIngredient = IngredientsGenerator.Ingredients.First();
            // Act 
            var response = await _client.GetAsync($"Ingredients/{expectedIngredient.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var ingredient = await response.Content.DeserializeAsync<IngredientDto>();
            // Assert
            ingredient.Should().BeEquivalentTo(expectedIngredient, 
                o => o.Excluding(i => i.Elixirs));
        }

        [Test]
        public async Task GetById_NotExistingId_ShouldReturnNotFound() {
            // Arrange
            var notExistingId = Guid.NewGuid();
            // Act 
            var response = await _client.GetAsync($"Ingredients/{notExistingId}");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}