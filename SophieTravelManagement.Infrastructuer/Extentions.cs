using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SophieTravelManagement.Application.Services;
using SophieTravelManagement.Infrastrcutuer.EF;
using SophieTravelManagement.Infrastrcutuer.Logging;
using SophieTravelManagement.Infrastrcutuer.Services;
using SophieTravelManagement.Shared.Abstractions.Commands;
using SophieTravelManagement.Shared.Queries;

namespace SophieTravelManagement.Infrastrcutuer;

public static class Extentions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSQLDB(configuration);
        services.AddQueries();

        services.AddSingleton<IWeatherService, DumbWeatherService>();

        services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));
        
        return services;
    }
}