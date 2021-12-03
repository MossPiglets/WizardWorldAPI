using System;
using System.Collections.Generic;
using WizardWorld.Persistance.Models.Elixirs;

namespace WizardWorld.Persistance.Models.Wizards {
    public class Wizard {
        public ICollection<Elixir> Elixirs { get; set; }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}