using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace WizardWorld.Application.Services.EmailProviders {
    public class SendGridEmailProvider : IEmailProvider {
        private readonly IConfiguration _config;
        public SendGridEmailProvider(IConfiguration config) {
            _config = config;
        }
        public async Task<Response> SendFeedbackEmailAsync(FeedbackEmail feedbackEmail) {
            var apiKey = _config.GetValue<string>("WizardWorldApiEmailKey");
            var sendGridClient = new SendGridClient(apiKey);
            var sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom("truemosspiglets@gmail.com", "MossPigletBot");
            sendGridMessage.AddTo("truemosspiglets@gmail.com");
            sendGridMessage.SetTemplateId("d-076542fe980544379eaab2d7f251dec2");
            sendGridMessage.SetTemplateData(new
            {
                type = feedbackEmail.FeedbackType.ToString(),
                id = feedbackEmail.EntityId,
                feedback = feedbackEmail.Feedback
            });

            return await sendGridClient.SendEmailAsync(sendGridMessage);
        }
    }
}