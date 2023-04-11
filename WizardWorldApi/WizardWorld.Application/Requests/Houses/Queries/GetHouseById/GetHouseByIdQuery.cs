using MediatR.AspNet;
using System;

namespace WizardWorld.Application.Requests.Houses.Queries.GetHouseById {
    public class GetHouseByIdQuery : IQuery<HouseDto> {
        public Guid Id { get; set; }
    }
}
