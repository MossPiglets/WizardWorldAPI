using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using WizardWorld.Application.Requests.Spells.Queries.GetSpells;
<<<<<<< HEAD
=======
using WizardWorld.Application.Services.EmailProviders;
>>>>>>> c425bb21f65b5497a5866c4f2f709cb2be6e03df

namespace WizardWorld.Application {
    public static class ServicesCollectionExtensions {
        public static void AddApplication(this IServiceCollection services) {
            services.AddScoped<IEmailProvider, SendGridEmailProvider>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(typeof(GetSpellsQuery));
        }
    }
}