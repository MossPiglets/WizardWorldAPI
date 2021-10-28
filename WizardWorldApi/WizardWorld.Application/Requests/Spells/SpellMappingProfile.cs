using AutoMapper;
using WizardWorld.Persistance.Models.Spells;

namespace WizardWorld.Application.Requests.Spells {
    public class SpellMappingProfile: Profile {
        public SpellMappingProfile() {
            CreateMap<SpellDto, Spell>();
        }
    }
}