using System;
using Bogus;
using Microsoft.EntityFrameworkCore;
using WizardWorld.Persistance.Models.Spells;

namespace WizardWorldApi.Tests.Integrations.SpellOptions {
	public class SpellOptions {
		public SpellOptions() {
			var options = new DbContextOptionsBuilder<InMemoryApplicationDbContext>()
			              .UseInMemoryDatabase(databaseName: "Test")
			              .Options;
			var spellFaker = new Faker<Spell>()
			                 .RuleFor(a => a.Id, f => Guid.NewGuid())
			                 .RuleFor(a => a.Name, f => f.Random.Word())
			                 .RuleFor(a => a.Effect, f => f.Lorem.Sentence())
			                 .RuleFor(a => a.CanBeVerbal, f => f.Random.Bool())
			                 .RuleFor(a => a.Type, f => f.PickRandom<SpellType>())
			                 .RuleFor(a => a.Light, f => f.PickRandom<SpellLight>())
			                 .RuleFor(a => a.Creator, f => f.Random.Words(2));
			using (var context = new InMemoryApplicationDbContext(options)) {
				var spells = spellFaker.Generate(10);
				context.Spells.AddRange(spells);
				context.SaveChanges();

			}

		}
	}
}