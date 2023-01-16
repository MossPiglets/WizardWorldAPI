using System.Linq;
using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using System;
using WizardWorld.Application.Requests.Spells;
using WizardWorldApi.Tests.Shared;

namespace WizardWorldApi.Tests.Unit {
    public class SpellMappingTests {
        private static IMapper _mapper;

        public SpellMappingTests() {
            var mappingConfig = new MapperConfiguration(mc
                => {
                mc.AddProfile(new SpellMappingProfile());
            });
            _mapper = mappingConfig.CreateMapper();
        }

        [Test]
        public void Map_Spell_ShouldReturnSpellDto() {
            // Arrange
            var spell = SpellsGenerator.Spells.First();

            // Act
            var spellDto = _mapper.Map<SpellDto>(spell);

            // Assert
            spellDto.Id.Should().Be(spell.Id);
            spellDto.Name.Should().Be(spell.Name);
            spellDto.Incantation.Should().Be(spell.Incantation);
            spellDto.Creator.Should().Be(spell.Creator);
            spellDto.Effect.Should().Be(spell.Effect);
            spellDto.CanBeVerbal.Should().Be(spell.CanBeVerbal);
            spellDto.Type.Should().Be(spell.Type);
            spellDto.Light.Should().Be(spell.Light);
        }
    }
}