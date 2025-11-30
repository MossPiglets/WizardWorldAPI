using Microsoft.Extensions.DependencyInjection;
using System;
using WizardWorld.Application.Services.EmailProviders;

namespace WizardWorld.Application {
    public static class ServicesCollectionExtensions {
        public static void AddApplication(this IServiceCollection services) {
            services.AddScoped<IEmailProvider, MailgunEmailProvider>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<IApplicationMarker>());
        }
    }
}