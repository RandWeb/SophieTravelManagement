using SophieTravelManagement.Domain.ValueObjects;

namespace SophieTravelManagement.Domain.Policies;

public record PolicyData(
    TravelDays Days,
    Constants.Gender Gender,
    ValueObjects.Temperature Temperature,
    Destination Destination);