using AutoMapper;
using CitiesBlog.Controllers.Content.Dto;
using System.Collections.Generic;
using System.Linq;

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
                .ForMember(dest => dest.AverageRating, opt => opt.MapFrom(src => src.Ratings.Any() ? src.Ratings.Average(r => r.Value) : 0))
                .Include<Domain.Entity.Article, ArticleDto>()
                .Include<Domain.Entity.Video, VideoDto>()
                .Include<Domain.Entity.Gallery, GalleryDto>();

            CreateMap<Domain.Entity.Article, ArticleDto>();
            CreateMap<Domain.Entity.Video, VideoDto>();
            CreateMap<Domain.Entity.Gallery, GalleryDto>();

            CreateMap<IEnumerable<Domain.Entity.Image>, List<string>>()
                .ConvertUsing((images, urls, context) =>
                {
                    return images.Select(image => image.Reference).ToList();
                });
        }
    }
}
