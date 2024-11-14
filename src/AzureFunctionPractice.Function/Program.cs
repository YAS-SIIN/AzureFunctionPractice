using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AzureFunctionPractice.Domain.DBContext;
using AzureFunctionPractice.Application.Services.Products;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();
builder.Services.AddDbContext<AppDBContext>(options => options.UseInMemoryDatabase("AppDBContext"));
builder.Services.AddScoped<IProductService, ProductService>();



builder.Build().Run();
