using CitiesBlog.Domain.Entity;
using Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Criteria
{
    public class FindRateCountByUserAndContent : ICriterion
    {
        public FindRateCountByUserAndContent(User user, Content content)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        public User User { get; }
        public Content Content { get;}
    }
}
