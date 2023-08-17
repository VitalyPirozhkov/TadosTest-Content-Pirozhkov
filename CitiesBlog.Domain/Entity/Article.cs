using CitiesBlog.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Entity
{
    public class Article : Content
    {
        [Obsolete("Only for reflection", true)]
        public Article() { }

        protected internal Article(string name, User creator, string text)
            : base(name, Enums.ContentType.Article, creator)
        {
            if(string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(text));
            Text = text;
        }

        public Article(long id, string name, User creator, string text, IEnumerable<Rating> ratings)
            : base(id, name, Enums.ContentType.Article, creator, ratings)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(text));
            Text = text;
        }

        public string Text { get; init; }
    }
}
