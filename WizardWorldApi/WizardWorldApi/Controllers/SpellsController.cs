using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WizardWorld.Application.Requests.Spells;
using WizardWorld.Application.Requests.Spells.Queries.GetSpellById;
using WizardWorld.Application.Requests.Spells.Queries.GetSpells;

namespace WizardWorldApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class SpellsController : ControllerBase {
        private readonly IMediator _mediator;

        public SpellsController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<SpellDto>> Get([FromQuery] GetSpellsQuery query) {
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<SpellDto> GetById([FromRoute] Guid id) {
            var query = new GetSpellByIdQuery {
                Id = id
            };
            return await _mediator.Send(query);
        }
    }
}