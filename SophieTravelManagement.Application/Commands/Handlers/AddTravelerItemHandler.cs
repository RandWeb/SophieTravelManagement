using SophieTravelManagement.Application.Exceptions;
using SophieTravelManagement.Domain.Entities;
using SophieTravelManagement.Domain.Repositories;
using SophieTravelManagement.Domain.ValueObjects;
using SophieTravelManagement.Shared.Abstractions.Commands;

namespace SophieTravelManagement.Application.Commands.Handlers;

public sealed class AddTravelerItemHandler : ICommandHandler<AddTravelerItemCommand>
{
    private readonly ITravelerCheckListRepository _repository;

    public AddTravelerItemHandler(ITravelerCheckListRepository repository)
    {
        _repository = repository;
    }


    public async Task HandleAsync(AddTravelerItemCommand command)
    {
        TravelerCheckList travelerCheckingList = await _repository.GetAsync(command.TravelerCheckListId);
     
        if (travelerCheckingList is null)
            throw new TravelerCheckListNotFoundException(command.TravelerCheckListId);

        TravelerItem travelerItem = new(command.Name, command.Quantity);
        
        travelerCheckingList.AddItem(travelerItem);

        await _repository.UpdateAsync(travelerCheckingList);
    }
}