using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WizardWorld.Application;
using WizardWorld.Persistance;


namespace WizardWorldApi {
    public class Startup {
        public Startup(IConfiguration configuration, IWebHostEnvironment env) {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }
        private IWebHostEnvironment _env { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            if (_env.IsProduction()) {
                services.AddApplicationDbContext(ConnectionStringBuilder.Build());
            }
            else {
                services.AddApplicationDbContext(Configuration.GetConnectionString("DefaultConnection"));
            }
            services.AddControllers();
            services.AddAppAutoMapper();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "WizardWorldApi", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WizardWorldApi v1"));

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}