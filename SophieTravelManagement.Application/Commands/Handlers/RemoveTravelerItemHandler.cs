using SophieTravelManagement.Application.Exceptions;
using SophieTravelManagement.Domain.Entities;
using SophieTravelManagement.Domain.Repositories;
using SophieTravelManagement.Shared.Abstractions.Commands;

namespace SophieTravelManagement.Application.Commands.Handlers;

public sealed class RemoveTravelerItemHandler : ICommandHandler<RemoveTravelerItemCommand>
{
    private readonly ITravelerCheckListRepository _repository;

    public RemoveTravelerItemHandler(ITravelerCheckListRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(RemoveTravelerItemCommand command)
    {
        TravelerCheckList travelerCheckList = await _repository.GetAsync(command.TravelerCheckListId);

        if (travelerCheckList is null)
            throw new TravelerCheckListNotFoundException(command.TravelerCheckListId);
        
        travelerCheckList.RemoveItem(command.Name);
        
        await _repository.UpdateAsync(travelerCheckList);
    }
}