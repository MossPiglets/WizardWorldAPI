using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WizardWorld.Persistance;

namespace WizardWorldApi.Middlewares {
    public class CounterMiddleware {
        private readonly RequestDelegate _next;

        public CounterMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ApplicationDbContext dbContext) {
            var counter = dbContext.Counters.Single();
            counter.CounterNumber++;
            await dbContext.SaveChangesAsync();
            await _next(context);
        }
    }
}