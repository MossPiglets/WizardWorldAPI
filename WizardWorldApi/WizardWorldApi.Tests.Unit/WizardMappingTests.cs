using AutoMapper;
using NUnit.Framework;
using WizardWorld.Application.Requests.Wizards;

namespace WizardWorldApi.Tests.Unit {
    public class WizardMappingTests {
        private static IMapper _mapper;

        public WizardMappingTests() {
            var mappingConfig = new MapperConfiguration(mc 
                => { mc.AddProfile(new WizardMappingProfile()); });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }
        [Test]
        public void Map_Wizard_ShouldReturnWizardDto() {
            // Arrange
            
            // Act
            
            // Assert
        }
    }
}