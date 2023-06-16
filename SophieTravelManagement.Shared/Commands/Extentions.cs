namespace SophieTravelManagement.Shared.Commands;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SophieTravelManagement.Shared.Abstractions.Commands;



public static class Extentions
{
    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        var assembly = Assembly.GetCallingAssembly();

        services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();

        services.Scan(s =>
               s.FromAssemblies(assembly)
                .AddClasses(c=>c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

        return services;
    }
}