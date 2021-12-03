using Bogus;
using System;
using System.Collections.Generic;
using WizardWorld.Persistance.Models.Spells;

namespace WizardWorldApi.Tests.Shared.Generators {
    public static class SpellsGenerator {
        public static IEnumerable<Spell> Spells { get; set; }

        static SpellsGenerator() {
            var spellFaker = new Faker<Spell>()
                .RuleFor(a => a.Id, f => Guid.NewGuid())
                .RuleFor(a => a.Name, f => f.Random.Word())
                .RuleFor(a => a.Incantation, f => f.Lorem.Sentence())
                .RuleFor(a => a.Effect, f => f.Lorem.Sentence())
                .RuleFor(a => a.CanBeVerbal, f => f.Random.Bool())
                .RuleFor(a => a.Type, f => f.PickRandom<SpellType>())
                .RuleFor(a => a.Light, f => f.PickRandom<SpellLight>())
                .RuleFor(a => a.Creator, f => f.Random.Words(2));
            Spells = spellFaker.Generate(10);
        }
    }
}