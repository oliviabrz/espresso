using Microsoft.OpenApi.Models;
using MySqlConnector;

namespace EspressoDataService.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder ConfigureApplicationBuilder(this WebApplicationBuilder builder)
    {   
        // Add services to the application
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Espresso API", Version = "v1" });
        });

        // Configure MySQL connection and add to DI container
        builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(builder.Configuration.GetConnectionString("EspressoDatabase")));

        return builder;
    }
}
