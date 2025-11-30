using System;
using MediatR.AspNet;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using WizardWorld.Application;
using WizardWorld.Persistance;
using WizardWorldApi.Extensions;
using WizardWorldApi;

// Top-level statements entry point
var builder = WebApplication.CreateBuilder(args);

// Services (migrated from Startup.ConfigureServices)
if (builder.Environment.IsProduction()) {
    builder.Services.AddApplicationDbContext(HerokuConnectingString.Get());
}
else {
    builder.Services.AddApplicationDbContext(builder.Configuration.GetConnectionString("DefaultConnection"));
}

builder.Services.AddApplication();
builder.Services.AddCors();

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options => { options.SerializerSettings.Converters.Add(new StringEnumConverter()); });

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "WizardWorldApi",
        Version = typeof(Program).Assembly.GetName().Version!.ToString(3),
        Contact = new OpenApiContact {
            Name = "Github",
            Url = new Uri("https://github.com/MossPiglets/WizardWorldAPI")
        }
    });
});
builder.Services.AddSwaggerGenNewtonsoftSupport();

var app = builder.Build();

// Middleware (migrated from Startup.Configure)
app.UseCounter();
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WizardWorldApi v1"));

// app.UseHttpsRedirection(); // kept commented as in original

app.UseRouting();
app.UseAuthorization();
app.UseCors(policyBuilder =>
    policyBuilder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.MapControllers();

// Apply migrations and seed data before running
await app.MigrateAsync();
app.Seed();
await app.RunAsync();

// For WebApplicationFactory<Program> compatibility in tests
namespace WizardWorldApi { public partial class Program { } }