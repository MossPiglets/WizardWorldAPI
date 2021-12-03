using System;
using System.Collections.Generic;

namespace WizardWorld.Persistance.Models.Wizards {
    public class Wizard {
        public ICollection<Guid> ElixirIds { get; set; }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}