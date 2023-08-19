namespace CitiesBlog.Controllers.Country.Actions.GetList
{
    using Api.Requests.Abstractions;
    using Dto;
    using Infrastructure.Pagination;
    using System.Collections.Generic;

    public record CountryGetListResponse(

        IEnumerable<CountryListItemDto> Countries

    ) : IResponse;
}