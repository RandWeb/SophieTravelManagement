using SophieTravelManagement.Shared.Abstractions.Exceptions;

namespace SophieTravelManagement.Application.Exceptions;

internal class TravelerCheckListAlreadyExistsException : TravelerCheckListException
{
    public string Name { get; }

    public TravelerCheckListAlreadyExistsException(string name) : base($"Traveler Checklist with name '{name}' already exists.")
        => Name = name;
}