using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AzureFunctionPractice.Domain.DBContext;
using AzureFunctionPractice.Application.Services.Products;
using AzureFunctionPractice.Function;
using FluentValidation;
using AzureFunctionPractice.Application;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();
builder.Services.AddDbContext<AppDBContext>(options => options.UseInMemoryDatabase("AppDBContext"));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddValidatorsFromAssembly(typeof(InjectApplication).Assembly);


var app = builder.Build();

// Initializing new data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.SeedData(services);
}

app.Run();

