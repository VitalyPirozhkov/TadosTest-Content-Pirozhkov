namespace CitiesBlog.Controllers.Content.Dto
{
    using User.Dto;
    using CitiesBlog.Domain.Enums;

    public abstract class ContentDto
    {
        public long Id { get; set; }

        public ContentType Type { get; set; }

        public UserDto Creator { get; set; }

        public string Name { get; set; }
        
        public decimal AverageRating { get; set; }
    }
}