using Microsoft.EntityFrameworkCore;
using SophieTravelManagement.Application.Dto;
using SophieTravelManagement.Application.Queries;
using SophieTravelManagement.Infrastrcutuer.EF.Models;
using SophieTravelManagement.Shared.Abstractions.Queries;

namespace SophieTravelManagement.Infrastrcutuer.EF.Queries.Handlers;

internal sealed class GetTravelerCheckListHandler : IQueryHandler<GetTravelerCheckList, TravelerCheckListDto>
{
    private readonly DbSet<TravelerCheckListReadModel> _travelerCheckLists;

    public GetTravelerCheckListHandler(DbSet<TravelerCheckListReadModel> travelerCheckLists)
    {
        _travelerCheckLists = travelerCheckLists;
    }

    public async Task<TravelerCheckListDto?> HandleAsync(GetTravelerCheckList query) =>
        await _travelerCheckLists
            .Include(pl => pl.Items)
            .Where(pl => pl.Id == query.Id)
            .Select(pl => pl.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
}