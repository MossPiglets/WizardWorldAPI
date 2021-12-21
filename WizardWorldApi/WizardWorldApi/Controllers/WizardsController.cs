using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WizardWorld.Application.Requests.Wizards;
using WizardWorld.Application.Requests.Wizards.Queries.GetWizardById;
using WizardWorld.Application.Requests.Wizards.Queries.GetWizards;

namespace WizardWorldApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class WizardsController : ControllerBase {
        private readonly IMediator _mediator;
        public WizardsController(IMediator mediator) {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<List<WizardDto>> Get([FromQuery] GetWizardsQuery query) {
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<WizardDto> GetById([FromRoute] Guid id) {
            var query = new GetWizardByIdQuery() {
                Id = id
            };
            return await _mediator.Send(query);
        }
    }
}