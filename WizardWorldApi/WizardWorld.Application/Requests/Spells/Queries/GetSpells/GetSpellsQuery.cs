using System.Collections.Generic;
using MediatR.AspNet;
using WizardWorld.Persistance.Models.Spells;

namespace WizardWorld.Application.Requests.Spells.Queries.GetSpells {
	public class GetSpellsQuery : IQuery<List<SpellDto>> {
		public string Name { get; set; }
		public SpellType? Type { get; set; }
		public string Incantation { get; set; }
	}
}