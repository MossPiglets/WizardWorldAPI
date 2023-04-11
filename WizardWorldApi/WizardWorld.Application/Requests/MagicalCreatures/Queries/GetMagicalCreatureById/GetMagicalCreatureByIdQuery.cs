using MediatR.AspNet;
using System;

namespace WizardWorld.Application.Requests.MagicalCreatures.Queries.GetMagicalCreatureById {
    public class GetMagicalCreatureByIdQuery : IQuery<MagicalCreatureDto> {
        public Guid Id { get; set; }
    }
}
