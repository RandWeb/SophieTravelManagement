using SophieTravelManagement.Shared.Abstractions.Exceptions;

namespace SophieTravelManagement.Application.Exceptions;

internal class TravelerCheckListNotFoundException : TravelerCheckListException
{
    public Guid Id { get; }

    public TravelerCheckListNotFoundException(Guid id) : base($"Traveler Checklist with Id {id} not found")
        => Id = id;
}