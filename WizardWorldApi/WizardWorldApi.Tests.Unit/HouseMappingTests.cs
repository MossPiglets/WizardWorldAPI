using System.Linq;
using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using WizardWorld.Application.Requests.Houses;
using WizardWorldApi.Tests.Shared;

namespace WizardWorldApi.Tests.Unit {
    public class HouseMappingTests {
        private static IMapper _mapper;

        public HouseMappingTests() {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new HouseMappingProfile()); });
            _mapper = mappingConfig.CreateMapper();
        }

    [Test]
    public void Map_House_ShouldReturnHouseDto() {
        // Arrange
        var house = HousesGenerator.Houses.First();

        // Act
        var houseDto = _mapper.Map<HouseDto>(house);

        // Assert
        houseDto.Id.Should().Be(house.Id);
        houseDto.Name.Should().Be(house.Name);
        houseDto.HouseColours.Should().Be(house.HouseColours);
        houseDto.Founder.Should().Be(house.Founder);
        houseDto.Animal.Should().Be(house.Animal);
        houseDto.Element.Should().Be(house.Element);
        houseDto.Ghost.Should().Be(house.Ghost);
        houseDto.CommonRoom.Should().Be(house.CommonRoom);
        houseDto.Heads.Should().BeEquivalentTo(house.Heads, o => o.Excluding(s => s.HouseId));
        houseDto.Traits.Should().BeEquivalentTo(house.Traits, o => o.Excluding(s => s.HouseId));
        }
    }
}
