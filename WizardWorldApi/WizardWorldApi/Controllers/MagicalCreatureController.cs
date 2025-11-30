using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WizardWorld.Application.Requests.MagicalCreatures;
using WizardWorld.Application.Requests.MagicalCreatures.Queries.GetMagicalCreatureById;
using WizardWorld.Application.Requests.MagicalCreatures.Queries.GetMagicalCreatures;

namespace WizardWorldApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class MagicalCreatureController : ControllerBase {
        private readonly IMediator _mediator;

        public MagicalCreatureController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<MagicalCreatureDto>> Get([FromQuery] GetMagicalCreaturesQuery query) {
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<MagicalCreatureDto> GetById([FromRoute] Guid id) {
            var query = new GetMagicalCreatureByIdQuery {
                Id = id
            };
            return await _mediator.Send(query);
        }
    }
}
