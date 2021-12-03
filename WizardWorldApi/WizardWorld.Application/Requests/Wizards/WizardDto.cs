using System;

namespace WizardWorld.Application.Requests.Wizards {
    public class WizardDto {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}