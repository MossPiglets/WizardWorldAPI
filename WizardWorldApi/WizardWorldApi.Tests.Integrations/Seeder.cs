using System;
using System.Collections.Generic;
using Bogus;
using WizardWorld.Persistance;
using WizardWorld.Persistance.Models.Spells;

namespace WizardWorldApi.Tests.Integrations {
    public static class Seeder {
        public static void Seed(ApplicationDbContext context) {
            context.AddRange(GetSpells(10));
            context.SaveChanges();
        }

        private static IEnumerable<Spell> GetSpells(int num) {
            var spellFaker = new Faker<Spell>()
                .RuleFor(a => a.Id, f => Guid.NewGuid())
                .RuleFor(a => a.Name, f => f.Random.Word())
                .RuleFor(a => a.Effect, f => f.Lorem.Sentence())
                .RuleFor(a => a.CanBeVerbal, f => f.Random.Bool())
                .RuleFor(a => a.Type, f => f.PickRandom<SpellType>())
                .RuleFor(a => a.Light, f => f.PickRandom<SpellLight>())
                .RuleFor(a => a.Creator, f => f.Random.Words(2));
            return spellFaker.Generate(num);
        }
    }
}