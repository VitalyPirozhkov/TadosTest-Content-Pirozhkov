using CitiesBlog.Domain.Entity;
using CitiesBlog.Domain.Services.Contents;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Services.Contents.Galleries
{
    public class GalleryService : ContentService, IGalleryService
    {
        public async Task<Gallery> CreateGalleryAsync(string name, User creator, string cover, IEnumerable<string> images)
        {
            /*logic*/
            return new Gallery(name, creator, cover, images);
        }
    }
}
