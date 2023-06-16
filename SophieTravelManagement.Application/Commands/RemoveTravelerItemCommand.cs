using SophieTravelManagement.Shared.Abstractions.Commands;

namespace SophieTravelManagement.Application.Commands;

public record RemoveTravelerItemCommand(Guid TravelerCheckListId,string Name):ICommand;