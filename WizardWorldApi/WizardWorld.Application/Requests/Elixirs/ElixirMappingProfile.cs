using AutoMapper;
using WizardWorld.Persistance.Models.Elixirs;
using WizardWorld.Persistance.Models.Wizards;

namespace WizardWorld.Application.Requests.Elixirs {
    public class ElixirMappingProfile : Profile {
        public ElixirMappingProfile() {
            CreateMap<Elixir, ElixirDto>();
            CreateMap<Wizard, ElixirInventorDto>();
        }
    }
}