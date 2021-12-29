using System;
using System.Collections.Generic;
using Bogus;
using WizardWorld.Persistance.Models.Houses;

namespace WizardWorldApi.Tests.Shared {
    public static class HousesGenerator {
        public static IEnumerable<House> Houses { get; set; }

        static HousesGenerator() {
            var houseFaker = new Faker<House>()
                .RuleFor(a => a.Id, f => Guid.NewGuid())
                .RuleFor(a => a.Name, f => f.Lorem.Sentence())
                .RuleFor(a => a.HouseColours, f => f.Lorem.Sentence())
                .RuleFor(a => a.Founder, f => f.Lorem.Sentence())
                .RuleFor(a => a.Animal, f => f.Lorem.Sentence())
                .RuleFor(a => a.Element, f => f.Lorem.Sentence())
                .RuleFor(a => a.Ghost, f => f.Lorem.Sentence())
                .RuleFor(a => a.CommonRoom, f => f.Lorem.Sentence())
                .RuleFor(a => a.Heads, (f, c) => new Faker<HouseHead>()
                                                 .RuleFor(a => a.Id, f => Guid.NewGuid())
                                                 .RuleFor(a => a.FirstName, f => f.Lorem.Sentence())
                                                 .RuleFor(a => a.LastName, f => f.Lorem.Sentence())
                                                 .RuleFor(a => a.HouseId, f => c.Id)
                                                 .Generate(3))
                .RuleFor(a => a.Traits, (f, c) => new Faker<Trait>()
                                                 .RuleFor(a => a.Id, f => Guid.NewGuid())
                                                 .RuleFor(a => a.Name, f => f.PickRandom<TraitName>())
                                                 .RuleFor(a => a.HouseId, f => c.Id)
                                                 .Generate(3));
            Houses = houseFaker.Generate(10);
        }
    }
}
