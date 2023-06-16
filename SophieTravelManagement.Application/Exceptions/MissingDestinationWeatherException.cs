using SophieTravelManagement.Domain.ValueObjects;
using SophieTravelManagement.Shared.Abstractions.Exceptions;

namespace SophieTravelManagement.Application.Exceptions;

public class MissingDestinationWeatherException : TravelerCheckListException
{
    public Destination Destination { get; }

    public MissingDestinationWeatherException(Destination destination) : base($"Couldn't fetch weather data for Destination '{destination.Country}/{destination.City}'.")
        => Destination = destination;
}