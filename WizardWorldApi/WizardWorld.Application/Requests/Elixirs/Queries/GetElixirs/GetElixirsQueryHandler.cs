using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WizardWorld.Persistance;
using WizardWorld.Persistance.Models.Elixirs;

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
                .Where(a => IsNameStartsWith(request.Name, a)
                            && IsManufacturerStartsWith(request.Manufacturer, a)
                            && IsDifficultyEqualTo(request.Difficulty, a)
                            && IsAnyInventorNameStartsWith(request.InventorFullName, a)
                            && IsAnyIngredientStartsWith(request.Ingredient, a))
                .Select(a => _mapper.Map<ElixirDto>(a)).ToListAsync(cancellationToken);
        }

        private static bool IsAnyIngredientStartsWith(string ingredient, Elixir a) {
            return (string.IsNullOrEmpty(ingredient)
                    || a.Ingredients.Any(b => b.Name.StartsWith(ingredient)));
        }

        private static bool IsAnyInventorNameStartsWith(string inventorFullName, Elixir a) {
            return (string.IsNullOrEmpty(inventorFullName)
                    || a.Inventors.Any(b => (b.FirstName.StartsWith(inventorFullName))
                                            || b.LastName.StartsWith(inventorFullName)));
        }

        private static bool IsDifficultyEqualTo(ElixirDifficulty? difficulty, Elixir a) {
            return (difficulty == null || a.Difficulty == difficulty);
        }

        private static bool IsManufacturerStartsWith(string manufacturer, Elixir a) {
            return (string.IsNullOrEmpty(manufacturer) ||
                    a.Manufacturer.StartsWith(manufacturer));
        }

        private static bool IsNameStartsWith(string name, Elixir a) {
            return (string.IsNullOrEmpty(name) || a.Name.StartsWith(name));
        }
    }
}