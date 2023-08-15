namespace CitiesBlog.Controllers.Content.Dto
{
    using System.Collections.Generic;

    public class GalleryDto : ContentDto
    {
        public string Cover { get; set; }
        
        public HashSet<string> Images { get; set; }
    }
}