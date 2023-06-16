using SophieTravelManagement.Domain.ValueObjects;

namespace SophieTravelManagement.Domain.Policies.Gender;

public sealed class FemaleGenderPolicy : ITravelerItemsPolicy
{
    public bool IsApplicable(PolicyData data)
        => data.Gender is Constants.Gender.Female;

    public IEnumerable<TravelerItem> GenerateItems(PolicyData data)
        => new List<TravelerItem>
        {
            new("Lipstick", 1),
            new("Powder", 1),
            new("Eyeliner", 1)
        };
}