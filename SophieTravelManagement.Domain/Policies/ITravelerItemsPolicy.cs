using SophieTravelManagement.Domain.ValueObjects;

namespace SophieTravelManagement.Domain.Policies;

public interface ITravelerItemsPolicy
{
    bool IsApplicable(PolicyData data);
    IEnumerable<TravelerItem> GenerateItems(PolicyData data);

}