namespace SophieTravelManagement.Shared.Abstractions.Exceptions;

public class TravelerCheckListException : Exception
{
    public TravelerCheckListException(string message) : base(message)
    {
    }
}