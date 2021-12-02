using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
