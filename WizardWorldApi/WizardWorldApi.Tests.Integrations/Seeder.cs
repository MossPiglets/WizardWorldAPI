using WizardWorld.Persistance;
using WizardWorldApi.Tests.Shared;

namespace WizardWorldApi.Tests.Integrations {
    public static class Seeder {
        public static void Seed(ApplicationDbContext context) {
            GeneratorManager.Generate();
            context.AddRange(SpellsGenerator.Spells);
            context.AddRange(IngredientsGenerator.Ingredients);
            context.AddRange(ElixirsGenerator.Elixirs);
            context.AddRange(WizardsGenerator.Wizards);
            context.AddRange(HousesGenerator.Houses);
            context.SaveChanges();
        }
    }
}