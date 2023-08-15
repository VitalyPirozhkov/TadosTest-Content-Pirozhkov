using CitiesBlog.Domain.Entity;
using CitiesBlog.Domain.ValueObjects;
using Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Commands.Contexts
{
    public class CreateRatingCommandContext : ICommandContext
    {
        public CreateRatingCommandContext(Rating rating, Content content) 
        {
            Content= content ?? throw new ArgumentNullException(nameof(content));
            Rating = rating ?? throw new ArgumentNullException(nameof(rating));
        }

        public Rating Rating { get;}
        public Content Content { get;}
    }
}
