using AutoMapper;
using WizardWorld.Persistance.Models.MagicalCreatures;

namespace WizardWorld.Application.Requests.MagicalCreatures {
    class MagicalCreatureMappingProfile : Profile {
        public MagicalCreatureMappingProfile() {
            CreateMap<MagicalCreature, MagicalCreatureDto>();
        }
    }
}
