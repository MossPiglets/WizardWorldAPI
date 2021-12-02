using MediatR.AspNet;
using System.Collections.Generic;

namespace WizardWorld.Application.Requests.Houses.Queries.GetHouses {
    public class GetHousesQuery : IQuery<List<HouseDto>> { }
}
