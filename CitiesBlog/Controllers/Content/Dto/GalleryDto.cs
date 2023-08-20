namespace CitiesBlog.Controllers.Content.Dto
{
    using System.Collections.Generic;

    public class GalleryDto : ContentDto
    {
        public string Cover { get; set; }
        
        public List<string> Images { get; set; }
    }
}