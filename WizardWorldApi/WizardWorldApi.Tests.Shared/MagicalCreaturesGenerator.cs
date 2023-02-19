using Bogus;
using System;
using System.Collections.Generic;
using WizardWorld.Persistance.Models.MagicalCreatures;
using System.Linq;

namespace WizardWorldApi.Tests.Shared.Generators {
    public class MagicalCreaturesGenerator {
        public static IEnumerable<MagicalCreature> MagicalCreatures { get; set; }

        static MagicalCreaturesGenerator() {
            

            var magicalCreatureFaker = new Faker<MagicalCreature>()
                .RuleFor(a => a.Id, f => Guid.NewGuid())
                .RuleFor(a => a.Name, f => f.Lorem.Sentence())
                .RuleFor(a => a.Description, f => f.Lorem.Sentence())
                .RuleFor(a => a.Classification, f => f.Random.Enum<CreatureClassificationByMinistryOfMagic>())
                .RuleFor(a => a.Status, f => f.Random.Enum<CreatureStatus>())
                .RuleFor(a => a.DangerLevel, f => f.Random.Enum<CreatureDangerLevel>())
                .RuleFor(a => a.NativeTo, f => f.Lorem.Sentence())
                .RuleFor(a => a.CreatureRelations, (f,c) => new Faker<CreatureRelation>()
                                                        .RuleFor(a => a.CreatureId, f => Guid.NewGuid())
                                                        .RuleFor(a => a.RelatedCreatureId, f => c.Id)
                                                        .Generate(3));

            MagicalCreatures = magicalCreatureFaker.Generate(10);
            //znajdź takie magical creatures których jakakolwiek creature relation ma Id = c8b887c1-a26b-4dab-9fdf-92d319480935
            //MagicalCreatures.Where(MagicalCreature => MagicalCreature.CreatureRelations.
        }
    }
}
