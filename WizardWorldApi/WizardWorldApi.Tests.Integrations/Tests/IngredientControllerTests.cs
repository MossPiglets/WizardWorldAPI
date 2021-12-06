using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using WizardWorld.Application.Requests.Ingredients;
using WizardWorldApi.Tests.Integrations.Extensions;
using WizardWorldApi.Tests.Integrations.Generators;

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
            var response = await _client.GetAsync("Ingredient");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var ingredients = await response.Content.DeserializeAsync<List<IngredientDto>>();
            // Assert
            ingredients.Should().NotBeEmpty();
            ingredients.Should()
                .BeEquivalentTo(expectedIngredients, o => o.Excluding(i => i.Elixirs));
        }
    }
}