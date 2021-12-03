using AutoMapper;
using WizardWorld.Persistance.Models.Elixirs;

namespace WizardWorld.Application.Requests.Elixirs {
    public class ElixirMappingProfile : Profile {
        public ElixirMappingProfile() {
            CreateMap<Elixir, ElixirDto>();
            CreateMap<Ingredient, IngredientDto>();
        }
    }
}