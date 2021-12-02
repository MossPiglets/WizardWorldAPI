using Bogus;
using System;
using System.Collections.Generic;
using WizardWorld.Persistance.Models.MagicalCreatures;

namespace WizardWorldApi.Tests.Integrations.Generators {
    public class MagicalCreaturesGenerator {
        public static IEnumerable<MagicalCreature> MagicalCreatures { get; set; }

        static MagicalCreaturesGenerator() {
            var magicalCreatureRelationFaker = new Faker<CreatureRelation>()
                .RuleFor(a => a.CreatureId, f => Guid.NewGuid())
                .RuleFor(a => a.RelatedCreatureId, f => Guid.NewGuid());

            List<CreatureRelation> fakeCreatureRelationCollection = magicalCreatureRelationFaker.Generate(3);

            var magicalCreatureFaker = new Faker<MagicalCreature>()
                .RuleFor(a => a.Id, f => fakeCreatureRelationCollection[0].CreatureId)
                .RuleFor(a => a.Name, f => f.Lorem.Sentence())
                .RuleFor(a => a.Description, f => f.Lorem.Sentence())
                .RuleFor(a => a.Classification, f => f.Random.Enum<CreatureClassificationByMinistryOfMagic>())
                .RuleFor(a => a.Status, f => f.Random.Enum<CreatureStatus>())
                .RuleFor(a => a.DangerLevel, f => f.Random.Enum<CreatureDangerLevel>())
                .RuleFor(a => a.NativeTo, f => f.Lorem.Sentence())
                .RuleFor(a => a.CreatureRelations, f => fakeCreatureRelationCollection);
            MagicalCreatures = magicalCreatureFaker.Generate(10);
        }
    }
}
