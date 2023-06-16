using SophieTravelManagement.Shared.Abstractions.Commands;

namespace SophieTravelManagement.Application.Commands;

public record TakeItem(Guid TravelerCheckListId,string Name):ICommand;
