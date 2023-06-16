using SophieTravelManagement.Application.Dto.External;
using SophieTravelManagement.Domain.ValueObjects;

namespace SophieTravelManagement.Application.Services;

public interface IWeatherService
{
    Task<WeatherDto> GetWeatherAsync(Destination localization);
}