using System.Linq;
using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using WizardWorld.Application.Requests.Ingredients;
using WizardWorldApi.Tests.Shared;

namespace WizardWorldApi.Tests.Unit {
    public class IngredientMappingTest {
        private static IMapper _mapper;

        public IngredientMappingTest() {
            var mappingConfig = new MapperConfiguration(mc 
                => { mc.AddProfile(new IngredientMappingProfile()); });
            _mapper = mappingConfig.CreateMapper();
        }

        [Test]
        public void Map_Ingredient_ShouldReturnIngredientDto() {
            // Arrange
            var ingredient = IngredientsGenerator.Ingredients.First();

            // Act
            var ingredientsDto = _mapper.Map<IngredientDto>(ingredient);

            // Assert
            ingredientsDto.Id.Should().Be(ingredient.Id);
            ingredientsDto.Name.Should().Be(ingredient.Name);
        }
        
    }
}