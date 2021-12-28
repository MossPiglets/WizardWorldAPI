using System.Collections.Generic;
using MediatR.AspNet;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WizardWorld.Persistance.Models.Elixirs;
using WizardWorld.Persistance.Models.Ingredients;
using WizardWorld.Persistance.Models.Wizards;

namespace WizardWorld.Application.Requests.Elixirs.Queries.GetElixirs {
    public class GetElixirsQuery : IQuery<List<ElixirDto>> {
        public string Name { get; set; }
        public ElixirDifficulty? Difficulty { get; set; }
        public string Ingredient { get; set; }
        public string InventorFullName { get; set; }
        public string Manufacturer { get; set; }
    }
}