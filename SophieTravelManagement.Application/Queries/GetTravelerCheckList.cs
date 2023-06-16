using SophieTravelManagement.Application.Dto;
using SophieTravelManagement.Shared.Abstractions.Queries;

namespace SophieTravelManagement.Application.Queries;

public class GetTravelerCheckList : IQuery<TravelerCheckListDto>
{
    public Guid Id { get; set; }
}