namespace SophieTravelManagement.Application.Dto;

public class TravelerCheckListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DestinationDto Destination { get; set; }
    public IEnumerable<TravelerItemDto> Items { get; set; }
}