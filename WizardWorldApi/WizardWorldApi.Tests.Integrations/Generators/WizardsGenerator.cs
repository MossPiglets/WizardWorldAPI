using System;
using System.Collections.Generic;
using Bogus;
using WizardWorld.Persistance.Models.Elixirs;
using WizardWorld.Persistance.Models.Wizards;

namespace WizardWorldApi.Tests.Integrations.Generators {
    public static class WizardsGenerator {
        public static IEnumerable<Wizard> Wizards { get; set; }
        static WizardsGenerator() {
            Wizards = new Faker<Wizard>()
                .RuleFor(a => a.Id, f => Guid.NewGuid())
                .RuleFor(a => a.FirstName, f => f.Random.Word())
                .RuleFor(a => a.LastName, f => f.Lorem.Word())
                .RuleFor(a => a.Elixirs, f => new List<Elixir>())
                .Generate(10);
        }
    }
}