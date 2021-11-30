using System;
using AutoMapper;
using Bogus;
using FluentAssertions;
using NUnit.Framework;
using WizardWorld.Application.Requests.Spells;
using WizardWorld.Persistance.Models.Spells;

namespace WizardWorldApi.Tests.Unit {
	public class SpellMappingTests {
		private static IMapper _mapper;
		public SpellMappingTests() {
			if (_mapper == null) {
				var mappingConfig = new MapperConfiguration(mc 
					=> { mc.AddProfile(new SpellMappingProfile()); });
				IMapper mapper = mappingConfig.CreateMapper();
				_mapper = mapper;
			}
		}

		[Test]
		public void Map_Spell_ShouldReturnSpellDto() {
			// Arrange
			var spellFaker = new Faker<Spell>()
			                .RuleFor(a => a.Id, f => Guid.NewGuid())
			                .RuleFor(a => a.Name, f => f.Lorem.Sentence())
			                .RuleFor(a => a.Incantation, f => f.Lorem.Sentence())
			                .RuleFor(a => a.Creator, f => f.Name.FullName())
			                .RuleFor(a => a.Effect, f => f.Lorem.Sentence())
			                .RuleFor(a => a.CanBeVerbal, f => f.Random.Bool())
			                .RuleFor(a => a.Type, f => f.Random.Enum<SpellType>())
			                .RuleFor(a => a.Light, f => f.Random.Enum<SpellLight>());
			var spell = spellFaker.Generate();
			
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