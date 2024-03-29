﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WizardWorld.Persistance;

namespace WizardWorld.Application.Requests.Spells.Queries.GetSpells {
    public class GetSpellsQueryHandler : IRequestHandler<GetSpellsQuery, List<SpellDto>> {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSpellsQueryHandler(ApplicationDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SpellDto>> Handle(GetSpellsQuery request, CancellationToken cancellationToken) {
            return await _context.Spells
                .AsNoTracking()
                .Where(a =>
                    (string.IsNullOrEmpty(request.Name) || a.Name.StartsWith(request.Name))
                    && (string.IsNullOrEmpty(request.Incantation) || a.Incantation.StartsWith(request.Incantation))
                    && (request.Type == null || a.Type == request.Type))
                .Select(a => _mapper.Map<SpellDto>(a)).ToListAsync(cancellationToken);
        }
    }
}