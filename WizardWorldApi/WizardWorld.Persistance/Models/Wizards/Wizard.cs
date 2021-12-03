using System;

namespace WizardWorld.Persistance.Models.Wizards {
    public class Wizard {
        public Guid ElixirId { get; set; }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}