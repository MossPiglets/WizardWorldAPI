using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WizardWorld.Persistance;

namespace WizardWorld.Application.Requests.Wizards.Queries.GetWizards {
    public class GetWizardsQueryHandler : IRequestHandler<GetWizardsQuery, List<WizardDto>> {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetWizardsQueryHandler(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<WizardDto>> Handle(GetWizardsQuery request, CancellationToken cancellationToken) {
            return await _context.Wizards
                .AsNoTracking()
                .Include(a => a.Elixirs)
                .Where(a => (string.IsNullOrEmpty(request.FirstName) || a.FirstName.StartsWith(request.FirstName))
                            && (string.IsNullOrEmpty(request.LastName) || a.LastName.StartsWith(request.LastName)))
                .Select(a => _mapper.Map<WizardDto>(a)).ToListAsync(cancellationToken);
        }
    }
}