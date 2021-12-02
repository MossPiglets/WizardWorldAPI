using AutoMapper;
using WizardWorld.Persistance.Models.Houses;

namespace WizardWorld.Application.Requests.Houses {
    class HouseMappingProfile : Profile {
        public HouseMappingProfile() {
            CreateMap<House, HouseDto>();
            CreateMap<Trait, TraitDto>();
            CreateMap<HouseHead, HouseHeadDto>();
        }
    }
}
