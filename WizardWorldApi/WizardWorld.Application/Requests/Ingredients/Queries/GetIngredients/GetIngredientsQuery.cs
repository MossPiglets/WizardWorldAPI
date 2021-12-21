using System.Collections.Generic;
using MediatR.AspNet;

namespace WizardWorld.Application.Requests.Ingredients.Queries.GetIngredients {
    public class GetIngredientsQuery : IQuery<List<IngredientDto>> {
        public string Name { get; set; }
    }
}