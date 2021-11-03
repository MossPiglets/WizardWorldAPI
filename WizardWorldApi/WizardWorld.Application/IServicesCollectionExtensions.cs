using System;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using WizardWorld.Application.Requests.Spells;
using WizardWorld.Persistance.Models.Spells;

namespace WizardWorld.Application {
    public static class IServicesCollectionExtensions {
        public static void AddAppAutoMapper(this IServiceCollection serviceExtensions) {
            serviceExtensions.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}