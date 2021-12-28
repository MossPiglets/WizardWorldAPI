using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MediatR.AspNet.Exceptions;
using Microsoft.EntityFrameworkCore;
using WizardWorld.Persistance;
using WizardWorld.Persistance.Models.Houses;

namespace WizardWorld.Application.Requests.Houses.Queries.GetHouseById {
	public class GetHouseByIdQueryHandler : IRequestHandler<GetHouseByIdQuery, HouseDto> {
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public GetHouseByIdQueryHandler(ApplicationDbContext context, IMapper mapper) {
			_context = context;
			_mapper = mapper;
		}

		public async Task<HouseDto> Handle(GetHouseByIdQuery request, CancellationToken cancellationToken) {
			var houseEntity = await _context.Houses
				.AsNoTracking()
				.Include(h => h.Traits)
				.Include(h => h.Heads)
				.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
			if (houseEntity == null) {
				throw new NotFoundException(typeof(House), request.Id.ToString());
			}

			return _mapper.Map<HouseDto>(houseEntity);
		}
	}
}
