using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WizardWorld.Persistance;

namespace WizardWorld.Application.Requests.Elixirs.Queries.GetElixirs {
    public class GetElixirsQueryHandler : IRequestHandler<GetElixirsQuery, List<ElixirDto>> {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetElixirsQueryHandler(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ElixirDto>> Handle(GetElixirsQuery request, CancellationToken cancellationToken) {
            return await _context.Elixirs
                .Include(a => a.Inventors)
                .Include(a => a.Ingredients)
                .Where(a => (string.IsNullOrEmpty(request.Name) || a.Name.StartsWith(request.Name))
                            && (string.IsNullOrEmpty(request.Manufacturer) ||
                                a.Manufacturer.StartsWith(request.Manufacturer))
                            && (request.Difficulty == null || a.Difficulty == request.Difficulty)
                            && (string.IsNullOrEmpty(request.InventorFullName)
                                || a.Inventors.Any(b => (request.InventorFullName.Contains(b.FirstName))
                                                        || request.InventorFullName.Contains(b.LastName)))
                            && (string.IsNullOrEmpty(request.Ingredient)
                                || a.Ingredients.Any(b => b.Name.StartsWith(request.Ingredient))))
                .Select(a => _mapper.Map<ElixirDto>(a)).ToListAsync(cancellationToken);
        }
    }
}