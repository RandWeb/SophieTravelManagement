using SophieTravelManagement.Domain.Constants;
using SophieTravelManagement.Domain.Entities;
using SophieTravelManagement.Domain.ValueObjects;

namespace SophieTravelManagement.Domain.Factories;

public interface ITravelerCheckListFactory
{
    TravelerCheckList Create(TravelerCheckListId id, TravelerCheckListName name, Destination destination);

    TravelerCheckList CreateWithDefaultItems(TravelerCheckListId id, TravelerCheckListName name, TravelDays days, Gender gender,
        Temperature temperature, Destination destination);
}