using SophieTravelManagement.Shared.Abstractions.Commands;

namespace SophieTravelManagement.Application.Commands;

public record RemoveTravelerCheckList(Guid Id):ICommand;