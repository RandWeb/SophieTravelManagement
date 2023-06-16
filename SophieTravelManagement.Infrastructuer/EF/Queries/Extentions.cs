using SophieTravelManagement.Application.Dto;
using SophieTravelManagement.Infrastrcutuer.EF.Models;

namespace SophieTravelManagement.Infrastrcutuer.EF.Queries;

internal static class Extentions
{
    public static TravelerCheckListDto AsDto(this TravelerCheckListReadModel readModel)
    {
        return new TravelerCheckListDto
        {
            Id = readModel.Id,
            Name = readModel.Name,
            Destination = new DestinationDto()
            {
                City = readModel.Destination?.City,
                Country = readModel.Destination?.Country
            },
            Items = readModel.Items?.Select(pi=> new TravelerItemDto
            {
                Name = pi.Name,
                Quantity = pi.Quantity,
                IsTaken = pi.IsTaken
            })
        };
    }
}