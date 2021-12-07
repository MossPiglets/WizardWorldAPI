using System;
using WizardWorld.Application.Requests.Feedback;

namespace WizardWorld.Application.Services.EmailProviders {
    public class FeedbackEmail {
        public FeedbackType FeedbackType { get; set; }
        public string Feedback { get; set; }
        public Guid? EntityId { get; set; }
    }
}