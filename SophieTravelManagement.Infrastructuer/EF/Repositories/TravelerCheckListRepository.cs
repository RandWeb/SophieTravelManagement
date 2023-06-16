using System.Xml;
using Microsoft.EntityFrameworkCore;
using SophieTravelManagement.Domain.Entities;
using SophieTravelManagement.Domain.Repositories;
using SophieTravelManagement.Domain.ValueObjects;
using SophieTravelManagement.Infrastrcutuer.EF.Contexts;

namespace SophieTravelManagement.Infrastrcutuer.EF.Repositories;

internal class TravelerCheckListRepository : ITravelerCheckListRepository
{
    private readonly DbSet<TravelerCheckList> _travelerCheckLists;
    private readonly WriteDbContext _writeDbContext;

    public TravelerCheckListRepository(DbSet<TravelerCheckList> travelerCheckLists, WriteDbContext writeDbContext)
    {
        _travelerCheckLists = travelerCheckLists;
        _writeDbContext = writeDbContext;
    }

    public async Task<TravelerCheckList> GetAsync(TravelerCheckListId id) =>
        await _travelerCheckLists.Include("_items").SingleOrDefaultAsync(p => p.Id == id);

    public async Task AddAsync(TravelerCheckList travelerCheckList)
    {
        await _travelerCheckLists.AddAsync(travelerCheckList);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TravelerCheckList travelerCheckList)
    {
        _travelerCheckLists.Update(travelerCheckList);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TravelerCheckList travelerCheckList)
    {
        _travelerCheckLists.Remove(travelerCheckList);
        await _writeDbContext.SaveChangesAsync();
    }
}