using System.Collections.Generic;
using MediatR.AspNet;

namespace WizardWorld.Application.Requests.Wizards.Queries.GetWizards {
    public class GetWizardsQuery : IQuery<List<WizardDto>> {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}