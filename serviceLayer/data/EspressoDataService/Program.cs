// Create a new WebApplication
using EspressoDataService.Api;
using EspressoDataService.Extensions;

// Create and configure WebApplicationBuilder
var builder = WebApplication
    .CreateBuilder(args)
    .ConfigureApplicationBuilder();

// Create the configured application from the builder
var app = builder
    .Build()
    .ConfigureWebApplication()
    .MapApiEndpoints();

app.Run();
return 0;
