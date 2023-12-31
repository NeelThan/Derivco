﻿using Application.Common.Behaviour;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
            this IServiceCollection services, 
            IConfiguration configuration)
    {
        services.AddMediatR(config => 
                config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehaviour<,>));
        return services;
    }
}