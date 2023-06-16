using SophieTravelManagement.Shared.Abstractions.Commands;

namespace SophieTravelManagement.Application.Commands;

public record AddTravelerItemCommand(Guid TravelerCheckListId, string Name, uint Quantity) : ICommand;
