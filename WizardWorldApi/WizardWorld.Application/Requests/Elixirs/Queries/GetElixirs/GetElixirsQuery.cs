using System.Collections.Generic;
using MediatR.AspNet;
using WizardWorld.Persistance.Models.Elixirs;

namespace WizardWorld.Application.Requests.Elixirs.Queries.GetElixirs {
    public class GetElixirsQuery : IQuery<List<ElixirDto>> {
        public string Name { get; set; }
        public ElixirDifficulty? Difficulty { get; set; }
        public string Ingredient { get; set; }
        public string InventorFullName { get; set; }
        public string Manufacturer { get; set; }
    }
}