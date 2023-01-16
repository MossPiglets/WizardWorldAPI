using System;
using MediatR.AspNet;

namespace WizardWorld.Application.Requests.Elixirs.Queries.GetElixirById {
    public class GetElixirByIdQuery : IQuery<ElixirDto> {
        public Guid Id { get; set; }
    }
}