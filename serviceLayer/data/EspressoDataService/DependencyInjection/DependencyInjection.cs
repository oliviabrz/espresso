using System;
using EspressoDataService.Api;

namespace EspressoDataService.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddSingleton<IMyInterface>(new MyClass1());

        return services;
    }
}
