using System.Threading.Tasks;
using SendGrid;

namespace WizardWorld.Application.Services.EmailProviders {
    public interface IEmailProvider {
        Task<Response> SendFeedbackEmailAsync(FeedbackEmail feedbackEmail);
    }
}