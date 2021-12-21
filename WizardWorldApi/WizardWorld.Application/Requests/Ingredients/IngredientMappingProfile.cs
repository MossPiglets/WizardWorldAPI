using AutoMapper;
using WizardWorld.Persistance.Models.Elixirs;
using WizardWorld.Persistance.Models.Ingredients;

namespace WizardWorld.Application.Requests.Ingredients {
    public class IngredientMappingProfile : Profile {
        public IngredientMappingProfile() {
            CreateMap<Ingredient, IngredientDto>();
        }
    }
}