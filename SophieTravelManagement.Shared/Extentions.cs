﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SophieTravelManagement.Shared.Exceptions;
using SophieTravelManagement.Shared.Services;

namespace SophieTravelManagement.Shared;

public static class Extentions
{
    public static IServiceCollection AddShared(this IServiceCollection services)
    {
        services.AddHostedService<AppInitializer>();
        services.AddScoped<ExceptionMiddleware>();
        return services;
    }

    public static IApplicationBuilder UseShared(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        return app;
    }
}