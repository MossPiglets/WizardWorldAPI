using System;
using Bogus;
using WizardWorld.Application.Requests.Feedback;
using WizardWorld.Application.Requests.Feedback.Commands.SendFeedback;

namespace WizardWorldApi.Tests.Shared {
    public static class FeedbackGenerator {
        public static SendFeedbackCommand Generate() {
            return new Faker<SendFeedbackCommand>()
                .RuleFor(a => a.Feedback, f => f.Lorem.Sentences(5))
                .RuleFor(a => a.FeedbackType, f => f.Random.Enum<FeedbackType>())
                .RuleFor(a => a.EntityId, f => Guid.NewGuid());
        }
    }
}