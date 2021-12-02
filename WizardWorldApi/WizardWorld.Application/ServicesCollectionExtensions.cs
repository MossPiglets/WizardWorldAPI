using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using WizardWorld.Application.Requests.Spells.Queries.GetSpells;
using WizardWorld.Application.Services.EmailProviders;

namespace WizardWorld.Application {
    public static class ServicesCollectionExtensions {
        public static void AddApplication(this IServiceCollection services) {
            services.AddScoped<IEmailProvider, SendGridEmailProvider>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(typeof(GetSpellsQuery));
        }
    }
}