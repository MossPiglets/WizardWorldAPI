using System;
using System.Collections.Generic;
using WizardWorld.Persistance.Models.Elixirs;

namespace WizardWorld.Persistance.Models.Ingredients {
    public class Ingredient {
        public ICollection<Elixir> Elixirs { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}