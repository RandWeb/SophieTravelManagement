using Microsoft.EntityFrameworkCore;
using SophieTravelManagement.Application.Services;
using SophieTravelManagement.Infrastrcutuer.EF.Models;

namespace SophieTravelManagement.Infrastrcutuer.EF.Services;

internal sealed class TravelerCheckListReadService : ITravelerCheckListReadService
{
    private readonly DbSet<TravelerCheckListReadModel> _travelerCheckList;

    public TravelerCheckListReadService(DbSet<TravelerCheckListReadModel> travelerCheckList)
    {
        _travelerCheckList = travelerCheckList;
    }

    public async Task<bool> ExistsByNameAsync(string name) => await _travelerCheckList.AnyAsync(pl => pl.Name == name);
}