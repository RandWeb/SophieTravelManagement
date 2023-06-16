using SophieTravelManagement.Shared.Abstractions.Exceptions;

namespace SophieTravelManagement.Domain.Exceptions;

public class TravelerCheckListIdException : TravelerCheckListException
{

    public TravelerCheckListIdException() : base("Traveler Checklist ID cannot be empty.")
    {
    }
}