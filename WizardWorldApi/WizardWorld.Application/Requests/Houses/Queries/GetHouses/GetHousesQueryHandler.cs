using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WizardWorld.Persistance;

namespace WizardWorld.Application.Requests.Houses.Queries.GetHouses {
    public class GetHousesQueryHandler : IRequestHandler<GetHousesQuery, List<HouseDto>> {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetHousesQueryHandler(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<HouseDto>> Handle(GetHousesQuery request, CancellationToken cancellationToken) {
            return await _context.Houses
                                .Include(h => h.Traits).Include(h => h.Heads)
                                .Select(a => _mapper.Map<HouseDto>(a)).ToListAsync(cancellationToken);
        }
    }
}
