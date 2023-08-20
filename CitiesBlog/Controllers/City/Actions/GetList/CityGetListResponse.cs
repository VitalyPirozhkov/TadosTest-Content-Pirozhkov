namespace CitiesBlog.Controllers.City.Actions.GetList
{
    using Api.Requests.Abstractions;
    using CitiesBlog.Controllers.Country.Dto;
    using Dto;
    using System.Collections.Generic;

    public record CityGetListResponse(
        IEnumerable<CityListItemDto> Cities

    ) : IResponse;
}