using System;
using System.Collections.Generic;
using Bogus;
using WizardWorld.Persistance.Models.Elixirs;

namespace WizardWorldApi.Tests.Integrations.Generators {
    public static class ElixirsGenerator {
        public static IEnumerable<Elixir> Elixirs { get; set; }

        static ElixirsGenerator() {
            Elixirs = Generate(10);
        }

        public static IEnumerable<Elixir> Generate(int number = 1) {
            return new Faker<Elixir>()
                .RuleFor(a => a.Id, f => Guid.NewGuid())
                .RuleFor(a => a.Name, f => f.Random.Word())
                .RuleFor(a => a.Characteristics, f => f.Lorem.Sentences(2))
                .RuleFor(a => a.Difficulty, f => f.PickRandom<ElixirDifficulty>())
                .RuleFor(a => a.Effect, f => f.Lorem.Sentences(3))
                .RuleFor(a => a.SideEffects, f => f.Lorem.Sentences(3))
                .RuleFor(a => a.Manufacturer, f => f.Random.Word())
                .RuleFor(a => a.Time, f => f.Lorem.Sentence())
                .RuleFor(a => a.Inventors, f => WizardsGenerator.Wizards)
                .RuleFor(a => a.Ingredients, f => IngredientsGenerator.Ingredients)    
                .Generate(number);
        }
    }
}