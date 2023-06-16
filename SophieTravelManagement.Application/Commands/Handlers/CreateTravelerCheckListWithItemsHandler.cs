using SophieTravelManagement.Application.Dto.External;
using SophieTravelManagement.Application.Exceptions;
using SophieTravelManagement.Application.Services;
using SophieTravelManagement.Domain.Entities;
using SophieTravelManagement.Domain.Factories;
using SophieTravelManagement.Domain.Repositories;
using SophieTravelManagement.Domain.ValueObjects;
using SophieTravelManagement.Shared.Abstractions.Commands;

namespace SophieTravelManagement.Application.Commands.Handlers;

public sealed class CreateTravelerCheckListWithItemsHandler : ICommandHandler<CreateTravelerCheckListWithItemsCommand>
{
    private readonly ITravelerCheckListRepository _repository;
    private readonly ITravelerCheckListFactory _factory;
    private readonly IWeatherService _weatherService;
    private readonly ITravelerCheckListReadService _readService;

    public CreateTravelerCheckListWithItemsHandler(
        ITravelerCheckListRepository repository,
        ITravelerCheckListFactory factory,
        IWeatherService weatherService)
    {
        _repository = repository;
        _factory = factory;
        _weatherService = weatherService;
    }

    public async Task HandleAsync(CreateTravelerCheckListWithItemsCommand command)
    {
        var(id,name,days,gender,DestiniationWriteCommand) = command;

        if (await _readService.ExistsByNameAsync(name))
            throw new TravelerCheckListAlreadyExistsException(name);

        Destination destination = new(DestiniationWriteCommand.City, DestiniationWriteCommand.Country);
        WeatherDto weather = await _weatherService.GetWeatherAsync(destination);
        
        if (weather is null)
            throw new MissingDestinationWeatherException(destination);

        TravelerCheckList travelerCheckList = _factory.CreateWithDefaultItems(id, name, days, gender, weather.Temperature, destination);
        
        await _repository.AddAsync(travelerCheckList);
    }
}