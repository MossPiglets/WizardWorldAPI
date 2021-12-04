using System;
using System.Collections.Generic;
using Bogus;
using WizardWorld.Persistance.Models.Ingredients;

namespace WizardWorldApi.Tests.Integrations.Generators {
    public static class IngredientsGenerator {
        public static IEnumerable<Ingredient> Ingredients { get; set; }

        static IngredientsGenerator() {
            Ingredients = Generate(10);
        }

        public static IEnumerable<Ingredient> Generate(int number = 1) {
            return new Faker<Ingredient>()
                .RuleFor(a => a.Id, f => Guid.NewGuid())
                .RuleFor(a => a.Name, f => f.Random.Word())
                .RuleFor(a => a.Elixirs, f => ElixirsGenerator.Generate(10))
                .Generate(10);
        }
    }
}