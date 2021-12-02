using System;
using MediatR.AspNet;

namespace WizardWorld.Application.Requests.MagicalCreatures.Queries.GetMagicalCreatureById {
    public class GetMagicalCreatureByIdQuery : IQuery<MagicalCreatureDto>{
        public Guid Id { get; set; }
    }
}
