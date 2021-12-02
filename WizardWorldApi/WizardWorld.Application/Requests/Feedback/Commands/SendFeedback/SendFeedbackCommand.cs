using System;
using MediatR.AspNet;

namespace WizardWorld.Application.Requests.Feedback.Commands.SendFeedback {
    public class SendFeedbackCommand : ICommand {
        public FeedbackType FeedbackType { get; set; }
        public string Feedback { get; set; }
        public Guid? EntityId { get; set; }
    }
}