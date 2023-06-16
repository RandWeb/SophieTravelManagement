using SophieTravelManagement.Application.Dto.External;
using SophieTravelManagement.Application.Services;
using SophieTravelManagement.Domain.ValueObjects;

namespace SophieTravelManagement.Infrastrcutuer.Services;

internal sealed class DumbWeatherService : IWeatherService
{
    public Task<WeatherDto> GetWeatherAsync(Destination localization)=> Task.FromResult(new WeatherDto(new Random().Next(5, 30)));
}