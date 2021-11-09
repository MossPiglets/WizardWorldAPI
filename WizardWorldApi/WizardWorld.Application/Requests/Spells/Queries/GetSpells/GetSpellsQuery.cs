using System.Collections.Generic;
using MediatR.AspNet;

namespace WizardWorld.Application.Requests.Spells.GetSpells {
	public class GetSpellsQuery : IQuery<List<SpellDto>> { }
}