using SophieTravelManagement.Shared.Abstractions.Commands;

namespace SophieTravelManagement.Application.Commands;

public record RemoveTravelerCheckListCommand(Guid Id):ICommand;