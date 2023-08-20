namespace CitiesBlog.Controllers.User.Actions.GetList
{
    using Api.Requests.Abstractions;
    using Dto;
    using System.Collections.Generic;

    public record UserGetListResponse(
        IEnumerable<UserListItemDto> Users) : IResponse;
}