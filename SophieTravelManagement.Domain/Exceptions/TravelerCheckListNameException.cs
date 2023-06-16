
using SophieTravelManagement.Shared.Abstractions.Exceptions;

namespace SophieTravelManagement.Domain.Exceptions;

public class TravelerCheckListNameException : TravelerCheckListException
{

    public TravelerCheckListNameException() : base("Traveler CheckList list name cannot be empty.")
    {
    }
}