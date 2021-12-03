using System;

namespace WizardWorld.Persistance.Models.Elixirs {
    public class Ingredient {
        public Guid ElixirId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}