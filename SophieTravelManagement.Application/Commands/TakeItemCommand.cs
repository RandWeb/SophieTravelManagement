using SophieTravelManagement.Shared.Abstractions.Commands;

namespace SophieTravelManagement.Application.Commands;

public record TakeItemCommand(Guid TravelerCheckListId,string Name):ICommand;
