using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WizardWorld.Persistance;

namespace WizardWorld.Application.Requests.Elixirs.Queries.GetElixirs {
    public class GetElixirsQueryHandler :IRequestHandler<GetElixirsQuery, ElixirDto> {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetElixirsQueryHandler(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }
        
        public Task<ElixirDto> Handle(GetElixirsQuery request, CancellationToken cancellationToken) {
            throw new System.NotImplementedException();
        }
    }
}