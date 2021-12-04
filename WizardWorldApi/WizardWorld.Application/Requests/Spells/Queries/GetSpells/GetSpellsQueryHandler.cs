using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WizardWorld.Persistance;
using WizardWorld.Persistance.Models.Spells;

namespace WizardWorld.Application.Requests.Spells.Queries.GetSpells {
    public class GetSpellsQueryHandler : IRequestHandler<GetSpellsQuery, List<SpellDto>> {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSpellsQueryHandler(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SpellDto>> Handle(GetSpellsQuery request, CancellationToken cancellationToken) {
            return await _context.Spells.Where(a => IsNameStartsWith(request.Name, a)
                    && IsIncantationStartsWith(request.Incantation, a)
                    && IsTypeEqualTo(request.Type, a))
                .Select(a => _mapper.Map<SpellDto>(a)).ToListAsync(cancellationToken);
        }

        private static bool IsTypeEqualTo(SpellType? type, Spell a) {
            return (type == null || a.Type == type);
        }

        private static bool IsIncantationStartsWith(string incantation, Spell a) {
            return (string.IsNullOrEmpty(incantation) || a.Incantation.StartsWith(incantation));
        }

        private static bool IsNameStartsWith(string name, Spell a) {
            return (string.IsNullOrEmpty(name) || a.Name.StartsWith(name));
        }
    }
}