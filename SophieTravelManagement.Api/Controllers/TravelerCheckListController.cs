using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SophieTravelManagement.Application.Commands;
using SophieTravelManagement.Application.Dto;
using SophieTravelManagement.Application.Queries;
using SophieTravelManagement.Shared.Abstractions.Commands;
using SophieTravelManagement.Shared.Abstractions.Queries;

namespace SophieTravelManagement.Api.Controllers;

public class TravelerCheckListController:BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public TravelerCheckListController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TravelerCheckListDto>> Get([FromRoute] GetTravelerCheckList query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TravelerCheckListDto>>> Get([FromQuery] SearchTravelerCheckList query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateTravelerCheckListWithItemsCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
    }

    [HttpPut("{TravelerCheckListId}/items")]
    public async Task<IActionResult> Put([FromBody] AddTravelerItemCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }

    [HttpPut("{TravelerCheckListId:guid}/items/{name}/Take")]
    public async Task<IActionResult> Put([FromBody] TakeItemCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }

    [HttpDelete("{TravelerCheckListId:guid}/items/{name}")]
    public async Task<IActionResult> Delete([FromBody] RemoveTravelerItemCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromBody] RemoveTravelerCheckListCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }

}