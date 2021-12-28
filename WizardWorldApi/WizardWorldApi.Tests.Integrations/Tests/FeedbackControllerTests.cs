using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using WizardWorldApi.Tests.Integrations.Data;
using WizardWorldApi.Tests.Shared;

namespace WizardWorldApi.Tests.Integrations.Tests {
    public class FeedbackControllerTests {
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
        public async Task Post_ShouldReturnResponse() {
            // Arrange
            var sendFeedbackCommand = FeedbackGenerator.Generate();
            EmailProviderMock.IsServiceAvailable = true;
            //Act
            var response = await _client.PostAsJsonAsync("Feedback", sendFeedbackCommand);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            TestData.FeedbackEmails.Should().ContainEquivalentOf(sendFeedbackCommand);
        }
        [Test]
        public async Task Post_ResponseIsNull_ShouldReturnBadGateaway() {
            // Arrange
            var sendFeedbackCommand = FeedbackGenerator.Generate();
            EmailProviderMock.IsServiceAvailable = false;
            //Act
            var response = await _client.PostAsJsonAsync("Feedback", sendFeedbackCommand);
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadGateway);
        }
    }
}