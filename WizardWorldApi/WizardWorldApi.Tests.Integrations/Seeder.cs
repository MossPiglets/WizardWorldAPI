﻿using WizardWorld.Persistance;
using WizardWorldApi.Tests.Shared;

namespace WizardWorldApi.Tests.Integrations {
    public static class Seeder {
        public static void Seed(ApplicationDbContext context) {
            context.AddRange(SpellsGenerator.Spells);
            context.SaveChanges();
        }
    }
}