using AutoMapper;
using NUnit.Framework;
using WizardWorld.Application.Requests.Ingredients;

namespace WizardWorldApi.Tests.Unit {
    public class IngredientMappingTest {
        private static IMapper _mapper;

        public IngredientMappingTest() {
            var mappingConfig = new MapperConfiguration(mc 
                => { mc.AddProfile(new IngredientMappingProfile()); });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }

        [Test]
        public void Map_Ingredient_ShouldReturnIngredientDto() {
            // Arrange
            
            // Act
            
            // Assert
        }
        
    }
}