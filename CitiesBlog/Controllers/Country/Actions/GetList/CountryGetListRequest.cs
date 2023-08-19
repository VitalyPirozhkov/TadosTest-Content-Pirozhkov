namespace CitiesBlog.Controllers.Country.Actions.GetList
{
    using Api.Requests.Abstractions;
    using CitiesBlog.Controllers.Country.Actions.GetList;
    using Infrastructure.Pagination;


    public record CountryGetListRequest : IRequest<CountryGetListResponse>
    {
        public string Search { get; init; }

    }
}