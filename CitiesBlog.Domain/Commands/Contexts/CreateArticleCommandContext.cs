using CitiesBlog.Domain.Entity;
using Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Commands.Contexts
{
    public class CreateArticleCommandContext : ICommandContext
    {
        public CreateArticleCommandContext(Article article) 
        { 
            Article= article ?? throw new ArgumentNullException(nameof(article));
        }

        public Article Article { get;}
    }
}
