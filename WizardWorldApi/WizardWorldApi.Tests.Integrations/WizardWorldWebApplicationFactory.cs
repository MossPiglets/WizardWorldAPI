using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
<<<<<<< HEAD
using System;
using System.Linq;
=======
using WizardWorld.Application.Services.EmailProviders;
>>>>>>> c425bb21f65b5497a5866c4f2f709cb2be6e03df
using WizardWorld.Persistance;

namespace WizardWorldApi.Tests.Integrations {
    public class WizardWorldWebApplicationFactory : WebApplicationFactory<Startup> {
        protected override void ConfigureWebHost(IWebHostBuilder builder) {
            builder.ConfigureServices((Action<IServiceCollection>)(services => {
                var descriptor = services.Single(d =>
                    d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                services.Remove(descriptor);

                var databaseName = Guid.NewGuid().ToString();

                services.AddDbContext<ApplicationDbContext>(o =>
                    o.UseInMemoryDatabase(databaseName));
                services.AddScoped<IEmailProvider, EmailProviderMock>();
                var provider = services.BuildServiceProvider();
                using var scope = provider.CreateScope();
                var scopeProvider = scope.ServiceProvider;
                var context = scopeProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                Seeder.Seed(context);
            }));
        }
    }
}