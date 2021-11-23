using System;
using MediatR.AspNet;

namespace WizardWorld.Application.Requests.Spells.Queries.GetSpellById {
	public class GetSpellByIdQuery : IQuery<SpellDto> {
		public Guid Id { get; set; }
	}
}