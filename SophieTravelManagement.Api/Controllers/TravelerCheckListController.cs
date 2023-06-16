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
    
    
}