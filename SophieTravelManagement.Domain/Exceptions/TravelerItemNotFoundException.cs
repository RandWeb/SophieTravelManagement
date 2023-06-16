using SophieTravelManagement.Shared.Abstractions.Exceptions;

namespace SophieTravelManagement.Domain.Exceptions;

public class TravelerItemNotFoundException : TravelerCheckListException
{
    public string ItemName { get; }

    public TravelerItemNotFoundException(string itemName) : base($"Traveler item '{itemName}' was not found.")
        => ItemName = itemName;
}