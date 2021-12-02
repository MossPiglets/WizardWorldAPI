using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using WizardWorldApi.Extensions;

namespace WizardWorldApi {
    public class Program {
        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Migrate().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
