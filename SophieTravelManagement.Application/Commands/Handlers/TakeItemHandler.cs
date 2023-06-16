using SophieTravelManagement.Application.Exceptions;
using SophieTravelManagement.Domain.Entities;
using SophieTravelManagement.Domain.Repositories;
using SophieTravelManagement.Shared.Abstractions.Commands;

namespace SophieTravelManagement.Application.Commands.Handlers;

public sealed class TakeItemHandler : ICommandHandler<TakeItemCommand>
{
    private readonly ITravelerCheckListRepository _repository;

    public TakeItemHandler(ITravelerCheckListRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(TakeItemCommand command)
    {
        TravelerCheckList travelerCheckList = await _repository.GetAsync(command.TravelerCheckListId);

        if (travelerCheckList is null)
            throw new TravelerCheckListNotFoundException(command.TravelerCheckListId);
        
        travelerCheckList.TakeItem(command.Name);
        
        await _repository.UpdateAsync(travelerCheckList);
    }
}
