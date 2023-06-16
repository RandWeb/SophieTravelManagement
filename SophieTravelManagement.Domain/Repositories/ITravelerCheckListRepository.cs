using SophieTravelManagement.Domain.Entities;
using SophieTravelManagement.Domain.ValueObjects;

namespace SophieTravelManagement.Domain.Repositories;

public interface ITravelerCheckListRepository
{
    Task<TravelerCheckList> GetAsync(TravelerCheckListId id);
    Task AddAsync(TravelerCheckList travelerCheckList);
    Task UpdateAsync(TravelerCheckList travelerCheckList);
    Task DeleteAsync(TravelerCheckList travelerCheckList);
}