using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WizardWorld.Application.Requests.Ingredients;
using WizardWorld.Application.Requests.Ingredients.Queries.GetIngredientById;
using WizardWorld.Application.Requests.Ingredients.Queries.GetIngredients;

namespace WizardWorldApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class IngredientController : ControllerBase {
        private readonly IMediator _mediator;

        public IngredientController(IMediator mediator) {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<List<IngredientDto>> Get([FromQuery] GetIngredientsQuery query) {
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<IngredientDto> GetById([FromRoute] Guid id) {
            var query = new GetIngredientByIdQuery() {
                Id = id
            };
            return await _mediator.Send(query);
        }
        
    }
}