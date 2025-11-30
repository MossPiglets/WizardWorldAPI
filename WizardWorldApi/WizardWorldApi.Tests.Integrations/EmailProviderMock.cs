using System.Threading.Tasks;
using WizardWorld.Application.Services.EmailProviders;
using WizardWorldApi.Tests.Integrations.Data;

namespace WizardWorldApi.Tests.Integrations {
    public class EmailProviderMock : IEmailProvider {
        public static bool IsServiceAvailable { get; set; }

        public Task<EmailResult> SendFeedbackEmailAsync(FeedbackEmail feedbackEmail) {
            if (IsServiceAvailable) {
                TestData.FeedbackEmails.Add(feedbackEmail);
                return Task.FromResult(new EmailResult { IsSuccess = true });
            }

            return Task.FromResult(new EmailResult { IsSuccess = false });
        }
    }
}