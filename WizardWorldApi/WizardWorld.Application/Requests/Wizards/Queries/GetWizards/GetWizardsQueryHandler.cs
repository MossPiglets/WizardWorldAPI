using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WizardWorld.Persistance;
using WizardWorld.Persistance.Models.Wizards;

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
                .Include(a => a.Elixirs)
                .Where(a => IsFirstNameStartsWith(request.FirstName, a)
                            && IsLastNameStartsWith(request.LastName, a))
                .Select(a => _mapper.Map<WizardDto>(a)).ToListAsync(cancellationToken);
        }

        private static bool IsLastNameStartsWith(string lastName, Wizard a) {
            return (string.IsNullOrEmpty(lastName) || a.LastName.StartsWith(lastName));
        }

        private static bool IsFirstNameStartsWith(string firstName, Wizard a) {
            return (string.IsNullOrEmpty(firstName) || a.FirstName.StartsWith(firstName));
        }
    }
}