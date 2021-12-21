using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MediatR.AspNet.Exceptions;
using Microsoft.EntityFrameworkCore;
using WizardWorld.Persistance;
using WizardWorld.Persistance.Models.Elixirs;

namespace WizardWorld.Application.Requests.Elixirs.Queries.GetElixirById {
    public class GetElixirByIdQueryHandler : IRequestHandler<GetElixirByIdQuery, ElixirDto> {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetElixirByIdQueryHandler(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ElixirDto> Handle(GetElixirByIdQuery request, CancellationToken cancellationToken) {
            var spellEntity = await _context.Elixirs
                .AsNoTracking()
                .Include(a => a.Ingredients)
                .Include(a => a.Inventors)
                .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
            if (spellEntity == null) {
                throw new NotFoundException(typeof(Elixir), request.Id.ToString());
            }

            return _mapper.Map<ElixirDto>(spellEntity);
        }
    }
}