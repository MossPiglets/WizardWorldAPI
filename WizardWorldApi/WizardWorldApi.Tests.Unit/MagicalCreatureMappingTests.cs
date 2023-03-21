using AutoMapper;
using Bogus;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WizardWorld.Application.Requests.MagicalCreatures;
using WizardWorld.Persistance.Models.MagicalCreatures;
using WizardWorldApi.Tests.Shared.Generators;


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
            var magicalCreature = MagicalCreaturesGenerator.MagicalCreatures.First();

            // Act
            var magicalCreatureDto = _mapper.Map<MagicalCreatureDto>(magicalCreature);

            // Assert
            magicalCreatureDto.Id.Should().Be(magicalCreature.Id);
            magicalCreatureDto.Name.Should().Be(magicalCreature.Name);
            magicalCreatureDto.Description.Should().Be(magicalCreature.Description);
            magicalCreatureDto.Classification.Should().Be(magicalCreature.Classification);
            magicalCreatureDto.Status.Should().Be(magicalCreature.Status);
            magicalCreatureDto.DangerousnessLevel.Should().Be(magicalCreature.DangerousnessLevel);
            magicalCreatureDto.NativeTo.Should().Be(magicalCreature.NativeTo);
            magicalCreatureDto.CreatureRelations.Should().BeEquivalentTo(magicalCreature.CreatureRelations);
        }
    }
}
