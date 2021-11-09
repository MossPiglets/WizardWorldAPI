using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WizardWorld.Application.Requests.Spells;
using WizardWorld.Application.Requests.Spells.GetSpells;

namespace WizardWorldApi.Controllers {
	[ApiController]
	[Route("[controller]")]
	public class SpellController : ControllerBase {
		private readonly IMediator _mediator;

		public SpellController(IMediator mediator) {
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<List<SpellDto>> Get() {
			var query = new GetSpellsQuery();
			return await _mediator.Send(query);
		}
	}
}