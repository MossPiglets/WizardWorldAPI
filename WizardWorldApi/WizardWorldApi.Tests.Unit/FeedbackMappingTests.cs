using System;
using AutoMapper;
using Bogus;
using FluentAssertions;
using NUnit.Framework;
using WizardWorld.Application.Requests.Feedback;
using WizardWorld.Application.Requests.Feedback.Commands.SendFeedback;
using WizardWorld.Application.Services.EmailProviders;

namespace WizardWorldApi.Tests.Unit {
    public class FeedbackMappingTests {
        private static IMapper _mapper;

        public FeedbackMappingTests() {
            if (_mapper == null) {
                var mappingConfig = new MapperConfiguration(mc => 
                    { mc.AddProfile(new FeedbackMappingProfile()); });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Test]
        public void Map_SendFeedbackCommand_ShouldReturnFeedback() {
            // Arrange
            var sendFeedbackCommandFaker = new Faker<SendFeedbackCommand>()
                .RuleFor(a => a.FeedbackType, f => f.Random.Enum<FeedbackType>())
                .RuleFor(a => a.Feedback, f => f.Lorem.Sentences(5))
                .RuleFor(a => a.EntityId, f => Guid.NewGuid());
            var sendFeedbackCommand = sendFeedbackCommandFaker.Generate();
            // Act
            var feedbackEmail = _mapper.Map<FeedbackEmail>(sendFeedbackCommand);
            // Assert
            feedbackEmail.FeedbackType.Should().Be(sendFeedbackCommand.FeedbackType);
            feedbackEmail.Feedback.Should().Be(sendFeedbackCommand.Feedback);
            feedbackEmail.EntityId.Should().Be(sendFeedbackCommand.EntityId);
        }
    }
}