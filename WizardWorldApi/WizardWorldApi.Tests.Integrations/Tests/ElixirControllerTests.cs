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
            var response = await _client.GetAsync($"Elixir/{expectedElixir.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var elixir = await response.Content.DeserializeAsync<ElixirDto>();
            // Assert
            elixir.Should().BeEquivalentTo(expectedElixir);
        }

        [Test]
        public async Task GetById_NotExistingId_ShouldReturnNotFound() {
            // Arrange
            var notExistingId = Guid.NewGuid();
            // Act 
            var response = await _client.GetAsync($"Elixir/{notExistingId}");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        
        [Test]
        public async Task Get_NoQueryParameters_ShouldReturnElixirsList() {
            // Arrange
            var expectedElixirs = ElixirsGenerator.Elixirs;
            // Act 
            var response = await _client.GetAsync("Elixir");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var elixirs = await response.Content.DeserializeAsync<List<ElixirDto>>();
            // Assert
            elixirs.Should().NotBeEmpty();
            elixirs.Should().BeEquivalentTo(expectedElixirs);
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
            var response = await _client.GetAsync($"Elixir", query);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var elixirs = await response.Content.DeserializeAsync<List<ElixirDto>>();
            // Assert
            elixirs.Should().NotBeEmpty();
            expectedElixirs.Where(a => a.Name.StartsWith(expectedElixir.Name))
                .Should().ContainEquivalentOf(expectedElixir);
        }
    }
}