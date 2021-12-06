using WizardWorld.Persistance;
using WizardWorldApi.Tests.Integrations.Generators;

namespace WizardWorldApi.Tests.Integrations {
    public static class Seeder {
        public static void Seed(ApplicationDbContext context) {
            context.AddRange(SpellsGenerator.Spells);
            context.AddRange(IngredientsGenerator.Ingredients);
            context.AddRange(ElixirsGenerator.Elixirs);
            context.AddRange(WizardsGenerator.Wizards);
            context.SaveChanges();
        }
    }
}