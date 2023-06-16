
using SophieTravelManagement.Shared.Abstractions.Exceptions;

namespace SophieTravelManagement.Domain.Exceptions;

public class TravelerItemNameException : TravelerCheckListException
{

    public TravelerItemNameException() : base("Traveler item name cannot be empty.")
    {
    }
}