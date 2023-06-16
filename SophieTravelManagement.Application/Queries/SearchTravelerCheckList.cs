using SophieTravelManagement.Application.Dto;
using SophieTravelManagement.Shared.Abstractions.Queries;

namespace SophieTravelManagement.Application.Queries;

public class SearchTravelerCheckList : IQuery<IEnumerable<TravelerCheckListDto>>
{
    public string SearchPharse { get; set; }
}