using CitiesBlog.Domain.Entity;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Services.Contents.Aritcles
{
    public class ArticleService : ContentService, IArticleService
    {
        public async Task<Article> CreateArticleAsync(string name, User creator, string text)
        {
            /*logic*/
            return new Article(name, creator, text);
        }
    }
}
