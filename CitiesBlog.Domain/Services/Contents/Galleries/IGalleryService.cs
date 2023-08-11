using CitiesBlog.Domain.Entity;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Services.Contents.Galleries
{
    public interface IGalleryService : IDomainService
    {
        Task<Gallery> CreateGalleryAsync(string name, User creator, string cover, IEnumerable<string> images);
    }
}
