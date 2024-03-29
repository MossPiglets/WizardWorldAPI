using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WizardWorld.Application.Requests.Houses;
using WizardWorld.Application.Requests.Houses.Queries.GetHouseById;
using WizardWorld.Application.Requests.Houses.Queries.GetHouses;

namespace WizardWorldApi.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class HousesController : ControllerBase {
        private readonly IMediator _mediator;

        public HousesController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<HouseDto>> Get([FromQuery] GetHousesQuery query) {
            return await _mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<HouseDto> GetById([FromRoute] Guid id) {
            var query = new GetHouseByIdQuery {
                Id = id
            };
            return await _mediator.Send(query);
        }
    }
}
