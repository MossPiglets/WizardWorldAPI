using AutoMapper;
using Bogus;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using WizardWorld.Application.Requests.MagicalCreatures;
using WizardWorld.Persistance.Models.MagicalCreatures;

namespace WizardWorldApi.Tests.Unit {
    public class MagicalCreatureMappingTests {
        private static IMapper _mapper;
        public MagicalCreatureMappingTests() {
            if (_mapper == null) {
                var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MagicalCreatureMappingProfile()); });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Test]
        public void Map_MagicalCreature_ShouldReturnMagicalCreatureDto() {
            // Arrange
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

            var magicalCreature = magicalCreatureFaker.Generate();

            // Act
            var spellDto = _mapper.Map<MagicalCreatureDto>(magicalCreature);

            // Assert
            spellDto.Id.Should().Be(magicalCreature.Id);
            spellDto.Name.Should().Be(magicalCreature.Name);
            spellDto.Description.Should().Be(magicalCreature.Description);
            spellDto.Classification.Should().Be(magicalCreature.Classification);
            spellDto.Status.Should().Be(magicalCreature.Status);
            spellDto.DangerLevel.Should().Be(magicalCreature.DangerLevel);
            spellDto.NativeTo.Should().Be(magicalCreature.NativeTo);
            spellDto.CreatureRelations.Should().BeEquivalentTo(fakeCreatureRelationCollection);
        }
    }
}
