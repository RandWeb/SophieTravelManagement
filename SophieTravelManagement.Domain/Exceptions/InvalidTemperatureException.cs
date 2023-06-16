using SophieTravelManagement.Shared.Abstractions.Exceptions;

namespace SophieTravelManagement.Domain.Exceptions;

internal class InvalidTemperatureException : TravelerCheckListException
{
    public double Temperature { get; }

    internal InvalidTemperatureException(double temperature) : base($"value {temperature} is invalid temperature.") =>
        Temperature = temperature;
}