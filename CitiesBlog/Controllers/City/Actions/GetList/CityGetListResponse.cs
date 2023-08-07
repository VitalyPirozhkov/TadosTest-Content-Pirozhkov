namespace CitiesBlog.Controllers.City.Actions.GetList
{
    using Dto;
    using Infrastructure.Pagination;


    public record CityGetListResponse(PaginatedList<CityListItemDto> Page);
}