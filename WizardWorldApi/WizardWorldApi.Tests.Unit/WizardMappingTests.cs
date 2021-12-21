using System.Linq;
using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using WizardWorld.Application.Requests.Wizards;
using WizardWorldApi.Tests.Shared;

namespace WizardWorldApi.Tests.Unit {
    public class WizardMappingTests {
        private static IMapper _mapper;

        public WizardMappingTests() {
            var mappingConfig = new MapperConfiguration(mc 
                => { mc.AddProfile(new WizardMappingProfile()); });
            _mapper = mappingConfig.CreateMapper();
        }
        [Test]
        public void Map_Wizard_ShouldReturnWizardDto() {
            // Arrange
            var wizard = WizardsGenerator.Wizards.First();

            // Act
            var wizardDto = _mapper.Map<WizardDto>(wizard);
            
            // Assert
            wizardDto.Id.Should().Be(wizard.Id);
            wizardDto.FirstName.Should().Be(wizard.FirstName);
            wizardDto.LastName.Should().Be(wizard.LastName);
            wizardDto.Elixirs.Should().BeEquivalentTo(wizard.Elixirs);
        }
    }
}