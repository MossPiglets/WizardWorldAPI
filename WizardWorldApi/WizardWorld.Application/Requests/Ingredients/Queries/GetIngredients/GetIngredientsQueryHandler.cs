using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WizardWorld.Persistance;

namespace WizardWorld.Application.Requests.Ingredients.Queries.GetIngredients {
    public class GetIngredientsQueryHandler : IRequestHandler<GetIngredientsQuery, List<IngredientDto>> {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetIngredientsQueryHandler(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<IngredientDto>> Handle(GetIngredientsQuery request, CancellationToken cancellationToken) {
            return await _context.Ingredients
                .AsNoTracking()
                .Include(a => a.Elixirs)
                .Where(a => (string.IsNullOrEmpty(request.Name) || a.Name.StartsWith(request.Name)))
                .Select(a => _mapper.Map<IngredientDto>(a)).ToListAsync(cancellationToken);
        }
    }
}