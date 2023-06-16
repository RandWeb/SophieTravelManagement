using SophieTravelManagement.Shared.Abstractions.Exceptions;

namespace SophieTravelManagement.Domain.Exceptions;

internal class InvalidTravelDaysException : TravelerCheckListException
{
    public ushort Days { get; }

    public InvalidTravelDaysException(ushort days) : base($"Value '{days}' is invalid travel days.")
        => Days = days;
}