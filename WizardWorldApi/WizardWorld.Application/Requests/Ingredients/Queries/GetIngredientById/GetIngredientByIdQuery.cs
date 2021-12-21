using System;
using MediatR.AspNet;

namespace WizardWorld.Application.Requests.Ingredients.Queries.GetIngredientById {
    public class GetIngredientByIdQuery : IQuery<IngredientDto> {
        public Guid Id { get; set; }
    }
}