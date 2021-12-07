using System;
using System.Collections.Generic;
using System.Linq;
using WizardWorld.Persistance.Models.Elixirs;
using WizardWorld.Persistance.Models.Ingredients;
using WizardWorld.Persistance.Models.Wizards;
using WizardWorldApi.Tests.Integrations.Extensions;

namespace WizardWorldApi.Tests.Integrations.Generators {
    public static class GeneratorManager {
        private static Random _random;

        public static void Generate() {
            _random = new Random();
            var elixirs = ElixirsGenerator.Elixirs;
            var ingredients = IngredientsGenerator.Ingredients;
            AddIngredientsToElixirs(elixirs, ingredients);
            var wizards = WizardsGenerator.Wizards;
            AddElixirsToWizards(wizards, elixirs);
        }

        private static void AddElixirsToWizards(IEnumerable<Wizard> wizards, IEnumerable<Elixir> elixirs) {
            foreach (var wizard in wizards) {
                for (int i = 0; i < 3; i++) {
                    var elixir = _random.Choice(elixirs);
                    if (!wizard.Elixirs.Contains(elixir)) {
                        elixir.Inventors.Add(wizard);
                        wizard.Elixirs.Add(elixir);
                    }
                }
            }
        }

        private static void AddIngredientsToElixirs(IEnumerable<Elixir> elixirs, IEnumerable<Ingredient> ingredients) {
            foreach (var elixir in elixirs) {
                for (int i = 0; i < 3; i++) {
                    var ingredient = _random.Choice(ingredients);
                    if (!elixir.Ingredients.Contains(ingredient)) {
                        ingredient.Elixirs.Add(elixir);
                        elixir.Ingredients.Add(ingredient);
                    }
                }
            }
        }
    }
}