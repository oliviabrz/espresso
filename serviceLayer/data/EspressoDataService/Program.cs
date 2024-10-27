// Create a new WebApplication
using EspressoDataService.Api;
using EspressoDataService.DependencyInjection;
using EspressoDataService.Extensions;

// Create and configure WebApplicationBuilder
var builder = WebApplication
    .CreateBuilder(args)
    .ConfigureApplicationBuilder();

    builder.Services.AddDependencyInjection();
    
// Create the configured application from the builder
var app = builder
    .Build()
    .ConfigureWebApplication()
    .MapGrinderApiEndpoints()
    .MapEspressoBeanApiEndpoints()
    .MapJournalEntryApiEndpoints();

app.Run();
return 0;
