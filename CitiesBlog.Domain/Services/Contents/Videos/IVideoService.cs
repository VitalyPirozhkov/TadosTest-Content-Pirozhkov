using CitiesBlog.Domain.Entity;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Services.Contents.Videos
{
    public interface IVideoService : IDomainService
    {
        Task<Video> CreateVideoAsync(string name, User creator, string reference);
    }
}
