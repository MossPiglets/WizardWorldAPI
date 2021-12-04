using System.Collections.Generic;
using MediatR.AspNet;
using WizardWorld.Persistance.Models.Elixirs;
using WizardWorld.Persistance.Models.Ingredients;
using WizardWorld.Persistance.Models.Wizards;

namespace WizardWorld.Application.Requests.Elixirs.Queries.GetElixirs {
    public class GetElixirsQuery : IQuery<ElixirDto> {
        public string Name { get; set; }
        public ElixirDifficulty Difficulty { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Wizard> Inventors { get; set; }
        public string Manufacturer { get; set; }
    }
}