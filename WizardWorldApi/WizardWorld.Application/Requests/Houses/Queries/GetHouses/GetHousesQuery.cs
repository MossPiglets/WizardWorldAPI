using System.Collections.Generic;
using MediatR.AspNet;

namespace WizardWorld.Application.Requests.Houses.Queries.GetHouses {
    public class GetHousesQuery : IQuery<List<HouseDto>> { }
}
