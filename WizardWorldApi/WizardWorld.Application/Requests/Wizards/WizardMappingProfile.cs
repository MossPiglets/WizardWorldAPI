using AutoMapper;
using WizardWorld.Persistance.Models.Wizards;

namespace WizardWorld.Application.Requests.Wizards {
    public class WizardMappingProfile : Profile {
        public WizardMappingProfile() {
            CreateMap<Wizard, WizardDto>();
        }
    }
}