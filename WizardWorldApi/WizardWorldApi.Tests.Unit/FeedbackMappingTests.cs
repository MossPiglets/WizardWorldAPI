using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using WizardWorld.Application.Requests.Feedback;
using WizardWorld.Application.Services.EmailProviders;
using WizardWorldApi.Tests.Shared;

namespace WizardWorldApi.Tests.Unit {
    public class FeedbackMappingTests {
        private static IMapper _mapper;

        public FeedbackMappingTests() {
            var mappingConfig = new MapperConfiguration(mc 
                => { mc.AddProfile(new FeedbackMappingProfile()); });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }

        [Test]
        public void Map_SendFeedbackCommand_ShouldReturnFeedback() {
            // Arrange
            var sendFeedbackCommand = FeedbackGenerator.Generate();
            // Act
            var feedbackEmail = _mapper.Map<FeedbackEmail>(sendFeedbackCommand);
            // Assert
            feedbackEmail.FeedbackType.Should().Be(sendFeedbackCommand.FeedbackType);
            feedbackEmail.Feedback.Should().Be(sendFeedbackCommand.Feedback);
            feedbackEmail.EntityId.Should().Be(sendFeedbackCommand.EntityId);
        }
    }
}