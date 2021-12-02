using MediatR.AspNet;
using System.Collections.Generic;


namespace WizardWorld.Application.Requests.MagicalCreatures.Queries.GetMagicalCreatures {
   public class GetMagicalCreaturesQuery : IQuery<List<MagicalCreatureDto>> { }
}
