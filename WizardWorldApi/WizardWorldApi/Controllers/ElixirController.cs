using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WizardWorld.Application.Requests.Elixirs;
using WizardWorld.Application.Requests.Elixirs.Queries.GetElixirById;
using WizardWorld.Application.Requests.Elixirs.Queries.GetElixirs;

namespace WizardWorldApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ElixirController : ControllerBase {
        private readonly IMediator _mediator;
        public ElixirController(IMediator mediator) {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<List<ElixirDto>> Get([FromQuery] GetElixirsQuery query) {
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<ElixirDto> GetById([FromRoute] Guid id) {
            var query = new GetElixirByIdQuery() {
                Id = id
            };
            return await _mediator.Send(query);
        }
    }
}