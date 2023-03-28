using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WizardWorld.Persistance;

namespace WizardWorld.Application.Requests.MagicalCreatures.Queries.GetMagicalCreatures {
    public class GetMagicalCreaturesQueryHandler : IRequestHandler<GetMagicalCreaturesQuery, List<MagicalCreatureDto>> {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMagicalCreaturesQueryHandler(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MagicalCreatureDto>> Handle(GetMagicalCreaturesQuery request, CancellationToken cancellationToken) {
            return await _context.MagicalCreatures
                .Include(a=>a.CreatureRelations)
                .Select(a => _mapper.Map<MagicalCreatureDto>(a)).ToListAsync(cancellationToken);
        }
    }
}
