using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using WizardWorld.Application.Requests.Wizards;
using WizardWorldApi.Tests.Integrations.Extensions;
using WizardWorldApi.Tests.Shared;

namespace WizardWorldApi.Tests.Integrations.Tests {
    public class WizardControllerTests {
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
        public async Task GetById_ShouldReturnWizard() {
            // Arrange
            var expectedWizard = WizardsGenerator.Wizards.First();
            // Act 
            var response = await _client.GetAsync($"Wizards/{expectedWizard.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var wizard = await response.Content.DeserializeAsync<WizardDto>();
            // Assert
            wizard.Should().BeEquivalentTo(expectedWizard,
                o => o.Excluding(i => i.Elixirs));
        }

        [Test]
        public async Task GetById_NotExistingId_ShouldReturnNotFound() {
            // Arrange
            var notExistingId = Guid.NewGuid();
            // Act 
            var response = await _client.GetAsync($"Wizards/{notExistingId}");
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Test]
        public async Task Get_NoQueryParameters_ShouldReturnWizardsList() {
            // Arrange
            var expectedWizards = WizardsGenerator.Wizards;
            // Act 
            var response = await _client.GetAsync("Wizards");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var wizards = await response.Content.DeserializeAsync<List<WizardDto>>();
            // Assert
            wizards.Should().NotBeEmpty();
            wizards.Should()
                .BeEquivalentTo(expectedWizards, o => o.Excluding(i => i.Elixirs));
        }

        [Test]
        public async Task Get_FirstName_ShouldReturnWizardsList() {
            // Arrange
            var expectedWizards = WizardsGenerator.Wizards;
            var expectedWizard = expectedWizards.First();
            var query = new Dictionary<string, string> {
                ["FirstName"] = expectedWizard.FirstName
            };
            // Act 
            var response = await _client.GetAsync("Wizards", query);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var wizards = await response.Content.DeserializeAsync<List<WizardDto>>();
            // Assert
            wizards.Should().NotBeEmpty();
            wizards.Where(a => a.FirstName.StartsWith(expectedWizard.FirstName)).Should()
                .ContainEquivalentOf(expectedWizard, o => o.Excluding(i => i.Elixirs));
        }

        [Test]
        public async Task Get_LastName_ShouldReturnWizardsList() {
            // Arrange
            var expectedWizards = WizardsGenerator.Wizards;
            var expectedWizard = expectedWizards.First();
            var query = new Dictionary<string, string> {
                ["LastName"] = expectedWizard.LastName
            };
            // Act 
            var response = await _client.GetAsync("Wizards", query);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var wizards = await response.Content.DeserializeAsync<List<WizardDto>>();
            // Assert
            wizards.Should().NotBeEmpty();
            wizards.Where(a => a.LastName.StartsWith(expectedWizard.LastName)).Should()
                .ContainEquivalentOf(expectedWizard, o => o.Excluding(i => i.Elixirs));
        }

        [Test]
        public async Task Get_FirstNameAndLastName_ShouldReturnWizardsList() {
            // Arrange
            var expectedWizards = WizardsGenerator.Wizards;
            var expectedWizard = expectedWizards.First();
            var query = new Dictionary<string, string> {
                ["FirstName"] = expectedWizard.FirstName,
                ["LastName"] = expectedWizard.LastName
            };
            // Act 
            var response = await _client.GetAsync("Wizards", query);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var wizards = await response.Content.DeserializeAsync<List<WizardDto>>();
            // Assert
            wizards.Should().NotBeEmpty();
            wizards.Where(a =>
                    a.FirstName.StartsWith(expectedWizard.FirstName) && a.LastName.StartsWith(expectedWizard.LastName))
                .Should()
                .ContainEquivalentOf(expectedWizard, o => o.Excluding(i => i.Elixirs));
        }
    }
}