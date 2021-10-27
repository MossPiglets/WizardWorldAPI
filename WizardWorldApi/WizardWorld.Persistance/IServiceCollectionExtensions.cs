using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WizardWorld.Persistance
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationDbContext(this IServiceCollection serviceExtensions, string connectionString) {
            serviceExtensions.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
        }
    }
}
