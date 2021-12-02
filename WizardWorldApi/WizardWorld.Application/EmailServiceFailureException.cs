using MediatR.AspNet.Exceptions;

namespace WizardWorld.Application {
	public class EmailServiceFailureException : ExternalServiceFailureException {
		public EmailServiceFailureException(string message) : base(message) { }
	}
}