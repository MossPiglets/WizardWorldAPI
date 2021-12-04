using System;
using System.Collections.Generic;
using WizardWorld.Application.Requests.Ingredients;
using WizardWorld.Application.Requests.Wizards;
using WizardWorld.Persistance.Models.Elixirs;

namespace WizardWorld.Application.Requests.Elixirs {
    public class ElixirDto {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Effect { get; set; }
        public string SideEffects { get; set; }
        public string Characteristics { get; set; }
        public string Time { get; set; }
        public ElixirDifficulty Difficulty { get; set; }
        public ICollection<IngredientDto> Ingredients { get; set; }
        public ICollection<WizardDto> Inventors { get; set; }
        public string Manufacturer { get; set; }
    }
}