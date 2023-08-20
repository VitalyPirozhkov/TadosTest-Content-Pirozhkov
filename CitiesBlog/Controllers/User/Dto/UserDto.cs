namespace CitiesBlog.Controllers.User.Dto
{
    using City.Dto;


    public class UserDto
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public CityDto City { get; set; }
    }
}