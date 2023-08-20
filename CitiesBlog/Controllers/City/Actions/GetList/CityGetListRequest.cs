namespace CitiesBlog.Controllers.City.Actions.GetList
{
    using Api.Requests.Abstractions;
    using CitiesBlog.Controllers.Country.Actions.GetList;


    public record CityGetListRequest : IRequest<CityGetListResponse>
    {
        public string Search { get; init; }
    }
}