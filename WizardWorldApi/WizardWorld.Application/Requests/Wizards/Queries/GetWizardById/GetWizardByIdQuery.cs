using System;
using MediatR.AspNet;

namespace WizardWorld.Application.Requests.Wizards.Queries.GetWizardById {
    public class GetWizardByIdQuery : IQuery<WizardDto> {
        public Guid Id { get; set; }
    }
}