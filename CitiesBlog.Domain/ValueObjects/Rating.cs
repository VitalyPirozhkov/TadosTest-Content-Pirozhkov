using CitiesBlog.Domain.Entity;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.ValueObjects
{
    public class Rating : IValueObjectWithId
    {
        [Obsolete("Only for reflection", true)]
        public Rating() { }

        protected internal Rating(int value, User user, Content content) 
        {
            if(value < 1 || value > 5)
                throw new ArgumentOutOfRangeException(nameof(value));
            User= user ?? throw new ArgumentNullException(nameof(user));
            Content = content?? throw new ArgumentNullException(nameof(content));
            Value= value;
        }

        public Rating(long id, int value, User user, Content content) : this(value, user, content)
        {
            Id = id;
        }

        public long Id { get; set; }

        public int Value { get; init; }

        public User User { get; init; }

        public Content Content { get; init; }
    }
}
