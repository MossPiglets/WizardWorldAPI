using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MediatR.AspNet.Exceptions;
using Microsoft.Extensions.Configuration;
using WizardWorld.Application.Services.EmailProviders;

namespace WizardWorld.Application.Requests.Feedback.Commands.SendFeedback {
    public class SendFeedbackCommandHandler : IRequestHandler<SendFeedbackCommand> {
        private readonly IMapper _mapper;
        private readonly IEmailProvider _provider;
        public SendFeedbackCommandHandler(IConfiguration configuration, IMapper mapper) {
            _mapper = mapper;
            _provider = new SendGridEmailProvider(configuration);
        }
        public async Task<Unit> Handle(SendFeedbackCommand request, CancellationToken cancellationToken) {
            var response = await _provider.SendFeedbackEmailAsync(_mapper.Map<FeedbackEmail>(request));
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted) {
                return Unit.Value;
            }

            throw new ExternalServiceFailureException("Email service failed");
        }
    }
}