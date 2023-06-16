using SophieTravelManagement.Shared.Abstractions.Commands;

namespace SophieTravelManagement.Application.Commands;

public record RemoveTravelerItem(Guid TravelerCheckListId,string Name):ICommand;