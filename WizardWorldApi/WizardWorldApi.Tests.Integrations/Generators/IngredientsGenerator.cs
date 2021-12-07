using System;
using System.Collections.Generic;
using Bogus;
using WizardWorld.Persistance.Models.Elixirs;
using WizardWorld.Persistance.Models.Ingredients;

namespace WizardWorldApi.Tests.Integrations.Generators {
    public static class IngredientsGenerator {
        public static IEnumerable<Ingredient> Ingredients { get; set; }

        static IngredientsGenerator() {
            Ingredients = new Faker<Ingredient>()
                .RuleFor(a => a.Id, f => Guid.NewGuid())
                .RuleFor(a => a.Name, f => f.Random.Word())
                .RuleFor(a => a.Elixirs, f => new List<Elixir>())
                .Generate(10);
        }
    }
}