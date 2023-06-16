using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SophieTravelManagement.Application.Services;
using SophieTravelManagement.Domain.Repositories;
using SophieTravelManagement.Infrastrcutuer.EF.Contexts;
using SophieTravelManagement.Infrastrcutuer.EF.Options;
using SophieTravelManagement.Infrastrcutuer.EF.Repositories;
using SophieTravelManagement.Infrastrcutuer.EF.Services;
using SophieTravelManagement.Shared.Options;

namespace SophieTravelManagement.Infrastrcutuer.EF;

internal static class Extentions
{
    public static IServiceCollection AddSQLDB(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITravelerCheckListRepository,TravelerCheckListRepository>();
        services.AddScoped<ITravelerCheckListReadService,TravelerCheckListReadService>();

        var options = configuration.GetOptions<DataBaseOptions>("DatabaseConnectionString");
        services.AddDbContext<ReadDbContext>(dbContextOptionsBuilder =>
        {
            dbContextOptionsBuilder.UseSqlServer(options.ConnectionString);
        });

        return services;
    }
}