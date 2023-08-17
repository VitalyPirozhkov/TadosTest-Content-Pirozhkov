using CitiesBlog.Domain.Commands.Contexts;
using CitiesBlog.Domain.Entity;
using Commands.Abstractions;
using Domain.Abstractions;
using Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Services.Contents.Aritcles
{
    public class ArticleService : ContentService, IArticleService
    {
        private readonly IAsyncCommandBuilder _commandBuilder;


        public ArticleService(IAsyncCommandBuilder commandBuilder)
        {
            _commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder));
        }

        public async Task<Article> CreateArticleAsync(string name, User creator, string text, CancellationToken cancellationToken = default)
        {
            Article article = new Article(name, creator, text);

            //await _commandBuilder.ExecuteAsync(new CreateArticleCommandContext(article), cancellationToken);
            await _commandBuilder.CreateAsync(article, cancellationToken);

            return article;
        }
    }
}
