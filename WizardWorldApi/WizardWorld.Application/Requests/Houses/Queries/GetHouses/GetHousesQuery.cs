using System.Collections.Generic;
using MediatR.AspNet;
using WizardWorld.Persistance.Models.Houses;

namespace WizardWorld.Application.Requests.Houses.Queries.GetHouses {
    public class GetHousesQuery : IQuery<List<HouseDto>> { }
}
