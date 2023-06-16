﻿using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SophieTravelManagement.Shared.Abstractions.Queries;

namespace SophieTravelManagement.Shared.Queries;

public static class Extentions
{
    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        var assembly = Assembly.GetCallingAssembly();
        services.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();
        services
            .Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c=>c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

        return services;
    }
}