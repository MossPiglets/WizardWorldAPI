using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MediatR.AspNet.Exceptions;
using Microsoft.EntityFrameworkCore;
using WizardWorld.Persistance;
using WizardWorld.Persistance.Models.Ingredients;

namespace WizardWorld.Application.Requests.Ingredients.Queries.GetIngredientById {
    public class GetIngredientByIdQueryHandler : IRequestHandler<GetIngredientByIdQuery, IngredientDto> {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetIngredientByIdQueryHandler(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IngredientDto> Handle(GetIngredientByIdQuery request, CancellationToken cancellationToken) {
            var ingredientEntity  = await _context.Ingredients
                .AsNoTracking()
                .Include(a => a.Elixirs)
                .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
            if (ingredientEntity == null) {
                throw new NotFoundException(typeof(Ingredient), request.Id.ToString());
            }

            return _mapper.Map<IngredientDto>(ingredientEntity);
        }
    }
}