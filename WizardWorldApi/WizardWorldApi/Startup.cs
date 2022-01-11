using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MediatR.AspNet;
using Newtonsoft.Json.Converters;
using WizardWorld.Application;
using WizardWorld.Persistance;
using Microsoft.AspNetCore.Mvc;

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
                services.AddApplicationDbContext(HerokuConnectingString.Get());
            }
            else {
                services.AddApplicationDbContext(Configuration.GetConnectionString("DefaultConnection"));
            }

            services.AddApplication();

            services.AddCors();

            services.AddControllers(o => o.Filters.AddMediatrExceptions())
                .AddNewtonsoftJson(options => {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "WizardWorldApi", 
                    Version = GetType().Assembly.GetName().Version.ToString(3),
                    Contact = new OpenApiContact {
                        Name = "Github",
                        Url = new Uri("https://github.com/MossPiglets/WizardWorldAPI")
                    }
                });
            });
            services.AddSwaggerGenNewtonsoftSupport();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WizardWorldApi v1"));

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(builder =>
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}