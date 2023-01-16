using AutoMapper;
using WizardWorld.Persistance.Models.Houses;

namespace WizardWorld.Application.Requests.Houses {
    public class HouseMappingProfile : Profile {
        public HouseMappingProfile() {
            CreateMap<House, HouseDto>();
            CreateMap<Trait, TraitDto>();
            CreateMap<HouseHead, HouseHeadDto>();
        }
    }
}
