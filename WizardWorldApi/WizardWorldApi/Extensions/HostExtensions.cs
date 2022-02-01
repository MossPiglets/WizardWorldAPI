using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WizardWorld.Persistance;
using WizardWorld.Persistance.Models.Counters;

namespace WizardWorldApi.Extensions {
    public static class HostExtensions {
        public static IHost Migrate(this IHost host) {
            using var scope = host.Services.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (context.Database.GetPendingMigrations().Any()) {
                logger.LogInformation("Migration started");
                context.Database.Migrate();
                logger.LogInformation("Migration finished");
            }
            else {
                logger.LogInformation("Migration not needed");
            }
            return host;
        }

        public static IHost Seed(this IHost host) {
            using var scope = host.Services.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (context.Database.GetPendingMigrations().Any()) {
                throw new InvalidOperationException("Apply migration before seeding");
            }
            logger.LogInformation("Seeding started");
            if (!context.Counters.Any()) {
                context.Counters.Add(new Counter {
                    Id = Guid.NewGuid(),
                    CounterNumber = 0
                });
                context.SaveChanges();
                logger.LogInformation("Counter: seeded");
            }
            logger.LogInformation("Seeding completed");
            return host;
        }
    }
}