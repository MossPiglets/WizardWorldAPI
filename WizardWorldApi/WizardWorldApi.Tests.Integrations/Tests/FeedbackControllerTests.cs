using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

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
        public async Task Post_ShouldReturnTask() {
            // Arrange
            
            // Act
            
            // Assert
        }
    }
}