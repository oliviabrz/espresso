using System;

namespace EspressoDataService.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureWebApplication(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Espresso API v1"));

        return app;
    }
}
