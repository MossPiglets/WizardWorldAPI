using AutoMapper;
using WizardWorld.Application.Requests.Feedback.Commands.SendFeedback;
using WizardWorld.Application.Services.EmailProviders;

namespace WizardWorld.Application.Requests.Feedback {
    public class FeedbackMappingProfile: Profile {
        public FeedbackMappingProfile() {
            CreateMap<SendFeedbackCommand, FeedbackEmail>();
        }
    }
}