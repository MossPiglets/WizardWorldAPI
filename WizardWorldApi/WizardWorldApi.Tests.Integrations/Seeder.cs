using System;
using WizardWorld.Persistance;
using WizardWorld.Persistance.Models.Counters;
using WizardWorldApi.Tests.Shared;

namespace WizardWorldApi.Tests.Integrations {
    public static class Seeder {
        public static void Seed(ApplicationDbContext context)
        {
            context.Counters.Add(new Counter
            {
                Id = Guid.NewGuid(),
                CounterNumber = 0
            });
            GeneratorManager.Generate();
            context.AddRange(SpellsGenerator.Spells);
            context.AddRange(IngredientsGenerator.Ingredients);
            context.AddRange(ElixirsGenerator.Elixirs);
            context.AddRange(WizardsGenerator.Wizards);
            context.AddRange(HousesGenerator.Houses);
            context.AddRange(MagicalCreaturesGenerator.MagicalCreatures);
            context.SaveChanges();
        }
    }
}