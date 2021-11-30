using System.Net;
using System.Threading.Tasks;
using SendGrid;
using WizardWorld.Application.Services.EmailProviders;

namespace WizardWorldApi.Tests.Integrations {
    public class SendGridEmailProviderMock : IEmailProvider {
        public Task<Response> SendFeedbackEmailAsync(FeedbackEmail feedbackEmail) {
            var response = new Response(HttpStatusCode.Accepted, null, null);
            return response;
        }
    }
}