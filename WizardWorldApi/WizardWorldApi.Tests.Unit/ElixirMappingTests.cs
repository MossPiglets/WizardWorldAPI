using System.Linq;
using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using WizardWorld.Application.Requests.Elixirs;
using WizardWorldApi.Tests.Shared;

namespace WizardWorldApi.Tests.Unit {
    public class ElixirMappingTests {
        private static IMapper _mapper;

        public ElixirMappingTests() {
            var mappingConfig = new MapperConfiguration(mc
                => {
                mc.AddProfile(new ElixirMappingProfile());
            });
            _mapper = mappingConfig.CreateMapper();
        }
        [Test]
        public void Map_Elixir_ShouldReturnElixirDto() {
            // Arrange
            var elixir = ElixirsGenerator.Elixirs.First();

            // Act
            var elixirDto = _mapper.Map<ElixirDto>(elixir);

            // Assert
            elixirDto.Id.Should().Be(elixir.Id);
            elixirDto.Characteristics.Should().Be(elixir.Characteristics);
            elixirDto.Difficulty.Should().Be(elixir.Difficulty);
            elixirDto.Effect.Should().Be(elixir.Effect);
            elixirDto.Ingredients.Should().BeEquivalentTo(elixir.Ingredients);
            elixirDto.Inventors.Should().BeEquivalentTo(elixir.Inventors);
            elixirDto.Manufacturer.Should().Be(elixir.Manufacturer);
            elixirDto.Name.Should().Be(elixir.Name);
            elixirDto.Time.Should().Be(elixir.Time);
            elixirDto.SideEffects.Should().Be(elixir.SideEffects);
        }
    }
}