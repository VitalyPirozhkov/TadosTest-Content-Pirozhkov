namespace CitiesBlog.Controllers.Country.Actions.Get
{
    using Api.Requests.Abstractions;
    using Dto;


    public record CountryGetResponse(CountryDto Country) : IResponse;
}