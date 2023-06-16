using Microsoft.EntityFrameworkCore;
using SophieTravelManagement.Application.Dto;
using SophieTravelManagement.Application.Queries;
using SophieTravelManagement.Infrastrcutuer.EF.Models;
using SophieTravelManagement.Shared.Abstractions.Queries;

namespace SophieTravelManagement.Infrastrcutuer.EF.Queries.Handlers;

internal sealed class SearchTravelerCheckListHandler : IQueryHandler<SearchTravelerCheckList, IEnumerable<TravelerCheckListDto>>
{
    private readonly DbSet<TravelerCheckListReadModel> _travelerCheckLists;

    public SearchTravelerCheckListHandler(DbSet<TravelerCheckListReadModel> travelerCheckLists)
    {
        _travelerCheckLists = travelerCheckLists;
    }

    public async Task<IEnumerable<TravelerCheckListDto>> HandleAsync(SearchTravelerCheckList query)
    {
        var dbQuery = _travelerCheckLists
            .Include(pl => pl.Items)
            .AsQueryable();

        if (query.SearchPharse is not null)
            dbQuery = dbQuery.Where(pl =>
                Microsoft.EntityFrameworkCore.EF.Functions.Like(pl.Name, $"%{query.SearchPharse}%"));

        return await dbQuery.Select(pl => pl.AsDto()).AsNoTracking().ToListAsync();
    }
}