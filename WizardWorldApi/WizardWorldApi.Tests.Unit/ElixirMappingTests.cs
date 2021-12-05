using AutoMapper;
using NUnit.Framework;
using WizardWorld.Application.Requests.Elixirs;

namespace WizardWorldApi.Tests.Unit {
    public class ElixirMappingTests {
        private static IMapper _mapper;

        public ElixirMappingTests() {
            var mappingConfig = new MapperConfiguration(mc
                => {
                mc.AddProfile(new ElixirMappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }
        [Test]
        public void Map_Elixir_ShouldReturnElixirDto() {
            // Arrange
            
            // Act
            
            // Assert
        }
    }
}