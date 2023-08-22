namespace CitiesBlog.Controllers.Content.Actions.GetList
{
    using Api.Requests.Abstractions;
    using CitiesBlog.Controllers.User.Actions.GetList;
    using CitiesBlog.Domain.Enums;

    public record ContentGetListRequest : IRequest<ContentGetListResponse>
    {
        public ContentType? Type { get; set; }

        public long UserId { get; set; }

        public string Search { get; set; }
    }
}