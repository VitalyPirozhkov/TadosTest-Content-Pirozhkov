namespace CitiesBlog.Controllers.Content.Dto
{
    using User.Dto;
    using CitiesBlog.Domain.Enums;

    public class ContentListItemDto
    {
        public long Id { get; set; }

        public ContentType Type { get; set; }

        public UserListItemDto Creator { get; set; }

        public string Name { get; set; }

    }
}