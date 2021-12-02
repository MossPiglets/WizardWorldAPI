using AutoMapper;
using MediatR;
using MediatR.AspNet.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WizardWorld.Persistance;
using WizardWorld.Persistance.Models.MagicalCreatures;

namespace WizardWorld.Application.Requests.MagicalCreatures.Queries.GetMagicalCreatureById {
    public class GetMagicalCreatureByIdQueryHandler : IRequestHandler<GetMagicalCreatureByIdQuery, MagicalCreatureDto> {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMagicalCreatureByIdQueryHandler(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MagicalCreatureDto> Handle(GetMagicalCreatureByIdQuery request, CancellationToken cancellationToken) {
            var magicalCreatuerEntity = await _context.MagicalCreatures.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken); ;

            if (magicalCreatuerEntity == null) {
                throw new NotFoundException(typeof(MagicalCreature), request.Id.ToString());
            }

            return _mapper.Map<MagicalCreatureDto>(magicalCreatuerEntity);
        }
    }
}
