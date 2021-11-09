using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WizardWorld.Persistance;

namespace WizardWorld.Application.Requests.Spells.GetSpells {
	public class GetSpellsQueryHandler : IRequestHandler<GetSpellsQuery, List<SpellDto>> {
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public GetSpellsQueryHandler(ApplicationDbContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<SpellDto>> Handle(GetSpellsQuery request, CancellationToken cancellationToken) {
			return await _context.Spells
			                     .Select(a => _mapper.Map<SpellDto>(a)).ToListAsync(cancellationToken);
		}
	}
}