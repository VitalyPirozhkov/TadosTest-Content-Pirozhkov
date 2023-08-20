namespace CitiesBlog.Controllers.Content.Actions.GetList
{
    using Api.Requests.Abstractions;
    using CitiesBlog.Controllers.User.Dto;
    using Dto;
    using System.Collections.Generic;

    public record ContentGetListResponse(
        IEnumerable<ContentListItemDto> Contents) : IResponse;
}