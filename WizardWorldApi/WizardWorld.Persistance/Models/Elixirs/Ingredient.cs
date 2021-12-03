using System;
using System.Collections.Generic;

namespace WizardWorld.Persistance.Models.Elixirs {
    public class Ingredient {
        public ICollection<Elixir> Elixirs { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}