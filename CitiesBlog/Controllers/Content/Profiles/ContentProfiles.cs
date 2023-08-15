using AutoMapper;
using CitiesBlog.Controllers.Content.Dto;

namespace CitiesBlog.Controllers.Content.Profiles
{
    public class ContentProfiles : Profile
    {
        public ContentProfiles() 
        {
            CreateMap<Domain.Entity.Content, ContentListItemDto>()
                .Include<Domain.Entity.Article, ArticleListItemDto>()
                .Include<Domain.Entity.Video, VideoListItemDto>()
                .Include<Domain.Entity.Gallery, GalleryListItemDto>();

            CreateMap<Domain.Entity.Article, ArticleListItemDto>();
            CreateMap<Domain.Entity.Video, VideoListItemDto>();
            CreateMap<Domain.Entity.Gallery, GalleryListItemDto>();

            CreateMap<Domain.Entity.Content, ContentDto>()
                .Include<Domain.Entity.Article, ArticleDto>()
                .Include<Domain.Entity.Video, VideoDto>()
                .Include<Domain.Entity.Gallery, GalleryDto>();

            CreateMap<Domain.Entity.Article, ArticleDto>();
            CreateMap<Domain.Entity.Video, VideoDto>();
            CreateMap<Domain.Entity.Gallery, GalleryDto>();
        }
    }
}
