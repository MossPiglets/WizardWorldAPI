using AutoMapper;
using MediatR;
using MediatR.AspNet.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WizardWorld.Persistance;
using WizardWorld.Persistance.Models.Spells;

namespace WizardWorld.Application.Requests.Spells.Queries.GetSpellById {
    public class GetSpellByIdQueryHandler : IRequestHandler<GetSpellByIdQuery, SpellDto> {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSpellByIdQueryHandler(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SpellDto> Handle(GetSpellByIdQuery request, CancellationToken cancellationToken) {
            var spellEntity = await _context.Spells.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
            if (spellEntity == null) {
                throw new NotFoundException(typeof(Spell), request.Id.ToString());
            }

            return _mapper.Map<SpellDto>(spellEntity);
        }
    }
}