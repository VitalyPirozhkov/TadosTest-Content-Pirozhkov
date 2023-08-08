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
        protected internal Rating(int value, User user) 
        {
            if(value < 1 || value > 5)
                throw new ArgumentOutOfRangeException(nameof(value));
            User= user ?? throw new ArgumentNullException(nameof(user));
            Value= value;
        }

        public Rating(long id, int value, User user) : this(value, user)
        {
            Id = id;
        }

        public long Id { get; set; }

        public int Value { get; init; }

        public User User { get; init; }
    }
}
