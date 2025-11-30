using System.Threading.Tasks;

namespace WizardWorld.Application.Services.EmailProviders {
    public interface IEmailProvider {
        Task<EmailResult> SendFeedbackEmailAsync(FeedbackEmail feedbackEmail);
    }

    public class EmailResult
    {
        public bool IsSuccess { get; set; }
    }
}