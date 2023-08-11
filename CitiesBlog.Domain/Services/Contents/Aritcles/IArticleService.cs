using CitiesBlog.Domain.Entity;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Services.Contents.Aritcles
{
    public interface IArticleService : IDomainService
    {
        Task<Article> CreateArticleAsync(string name, User creator, string text);
    }
}
