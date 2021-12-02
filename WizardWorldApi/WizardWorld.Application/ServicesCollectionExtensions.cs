using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using WizardWorld.Application.Requests.Spells.Queries.GetSpells;

namespace WizardWorld.Application {
    public static class ServicesCollectionExtensions {
        public static void AddApplication(this IServiceCollection serviceExtensions) {
            serviceExtensions.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            serviceExtensions.AddMediatR(typeof(GetSpellsQuery));
        }
    }
}