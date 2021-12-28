using System.Net;
using System.Threading.Tasks;
using SendGrid;
using WizardWorld.Application.Services.EmailProviders;
using WizardWorldApi.Tests.Integrations.Data;

namespace WizardWorldApi.Tests.Integrations {
    public class EmailProviderMock : IEmailProvider {
        public static bool IsServiceAvailable { get; set; }

        public Task<Response> SendFeedbackEmailAsync(FeedbackEmail feedbackEmail) {
            if (IsServiceAvailable) {
                var response = new Response(HttpStatusCode.Accepted, null, null);
                TestData.FeedbackEmails.Add(feedbackEmail);
                return Task.FromResult(response);
            }

            return Task.FromResult(new Response(HttpStatusCode.BadRequest, null, null));
        }
    }
}