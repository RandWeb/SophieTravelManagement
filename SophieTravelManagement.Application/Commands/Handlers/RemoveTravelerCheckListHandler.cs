using SophieTravelManagement.Application.Exceptions;
using SophieTravelManagement.Domain.Entities;
using SophieTravelManagement.Domain.Repositories;
using SophieTravelManagement.Shared.Abstractions.Commands;

namespace SophieTravelManagement.Application.Commands.Handlers;

public sealed class RemoveTravelerCheckListHandler : ICommandHandler<RemoveTravelerCheckListCommand>
{
    private readonly ITravelerCheckListRepository _repository;

    public RemoveTravelerCheckListHandler(ITravelerCheckListRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(RemoveTravelerCheckListCommand command)
    {
        TravelerCheckList travelerCheckList = await _repository.GetAsync(command.Id);

        if (travelerCheckList is null)
            throw new TravelerCheckListNotFoundException(command.Id);

        await _repository.DeleteAsync(travelerCheckList);
    }
}