using Functions.DurableFunctions.Helpers;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();



var configBuilder = new ConfigurationBuilder()
.SetBasePath(GetFunctionDirectory())
.AddJsonFile("appsettings.json", false, true)
.AddEnvironmentVariables();

var serviceProvider = builder.Services.BuildServiceProvider();

var configurationRoot = serviceProvider.GetService<IConfiguration>();
configBuilder.AddConfiguration(configurationRoot);
var configuration = configBuilder.Build();
builder.Services.Replace(ServiceDescriptor.Singleton(typeof(IConfiguration), configuration));


builder.Services.AddSingleton<ServiceBusHelper>();

builder.Build().Run();

 static string GetFunctionDirectory()
{
    var assembly = Assembly.GetExecutingAssembly();
    return new FileInfo(assembly.Location).Directory?.FullName;
}
