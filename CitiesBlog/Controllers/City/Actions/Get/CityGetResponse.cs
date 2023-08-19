namespace CitiesBlog.Controllers.City.Actions.Get
{
    using Api.Requests.Abstractions;
    using Dto;


    public record CityGetResponse(CityDto City) : IResponse;
}