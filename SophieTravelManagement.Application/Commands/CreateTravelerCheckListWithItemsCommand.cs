using SophieTravelManagement.Domain.Constants;
using SophieTravelManagement.Shared.Abstractions.Commands;

namespace SophieTravelManagement.Application.Commands;

public record CreateTravelerCheckListWithItemsCommand(Guid Id,string Name,ushort Days,Gender Gender,DestinationWriteCommand Destination) : ICommand;

public abstract record DestinationWriteCommand(string City,string Country);