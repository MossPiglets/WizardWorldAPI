using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MediatR.AspNet.Exceptions;
using Microsoft.EntityFrameworkCore;
using WizardWorld.Persistance;
using WizardWorld.Persistance.Models.Wizards;

namespace WizardWorld.Application.Requests.Wizards.Queries.GetWizardById {
    public class GetWizardByIdQueryHandler : IRequestHandler<GetWizardByIdQuery, WizardDto> {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetWizardByIdQueryHandler(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WizardDto> Handle(GetWizardByIdQuery request, CancellationToken cancellationToken) {
            var spellEntity = await _context.Wizards
                .Include(a => a.Elixirs)
                .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
            if (spellEntity == null) {
                throw new NotFoundException(typeof(Wizard), request.Id.ToString());
            }

            return _mapper.Map<WizardDto>(spellEntity);
        }
    }
}