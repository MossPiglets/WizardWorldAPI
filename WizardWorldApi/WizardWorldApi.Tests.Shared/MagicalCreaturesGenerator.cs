using Bogus;
using System;
using System.Collections.Generic;
using WizardWorld.Persistance.Models.MagicalCreatures;

namespace WizardWorldApi.Tests.Shared {
    public class MagicalCreaturesGenerator {
        public static IEnumerable<MagicalCreature> MagicalCreatures { get; set; }

        static MagicalCreaturesGenerator() {
            
            var magicalCreatureFaker = new Faker<MagicalCreature>()
                .RuleFor(a => a.Id, f => Guid.NewGuid())
                .RuleFor(a => a.Name, f => f.Lorem.Sentence())
                .RuleFor(a => a.Description, f => f.Lorem.Sentence())
                .RuleFor(a => a.Classification, f => f.Random.Enum<CreatureClassificationByMinistryOfMagic>())
                .RuleFor(a => a.Status, f => f.Random.Enum<CreatureStatus>())
                .RuleFor(a => a.DangerousnessLevel, f => f.Random.Enum<CreatureDangerousnessLevel>())
                .RuleFor(a => a.NativeTo, f => f.Lorem.Sentence())
                .RuleFor(a => a.CreatureRelations, (f,c) => new Faker<CreatureRelation>()
                                                        .RuleFor(a => a.CreatureId, f => c.Id)
                                                        .RuleFor(a => a.RelatedCreatureId, f => Guid.NewGuid())
                                                        .Generate(3));

            MagicalCreatures = magicalCreatureFaker.Generate(10);
        }
    }
}
