using SophieTravelManagement.Domain.Constants;
using SophieTravelManagement.Shared.Abstractions.Commands;

namespace SophieTravelManagement.Application.Commands;

public record CreateTravelerCheckListWithItems(Guid Id,string Name,ushort Days,Gender Gender,DestinationWriteModel Destination) : ICommand;

public abstract record DestinationWriteModel(string City,string Country);