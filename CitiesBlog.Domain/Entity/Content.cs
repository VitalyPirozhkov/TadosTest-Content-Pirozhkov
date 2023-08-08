using CitiesBlog.Domain.Enums;
using CitiesBlog.Domain.ValueObjects;
using Domain.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Entity
{
    public abstract class Content : IEntity
    {
        private readonly ISet<Rating> _ratings = new HashSet<Rating>();

        protected Content(string name, ContentType type, User creator) 
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            Creator= creator ?? throw new ArgumentNullException(nameof(creator));
            Type = type;
            Name = name;

        }

        protected Content(long id, string name, ContentType type, User creator, IEnumerable<Rating> ratings) : this(name, type, creator)
        {
            if ( ratings==null )
                throw new ArgumentNullException(nameof(ratings));
            
            Id = id;

            foreach (var rating in ratings)
            {
                _ratings.Add(rating);
            }
        }

        public long Id { get; set; }

        public string Name { get; init; }

        public ContentType Type { get; init; }

        public User Creator { get; init; }

        public IEnumerable<Rating> Ratings => _ratings.AsEnumerable();

        protected internal void Rate(int value, User user)
        {
            if(user == null)
                throw new ArgumentNullException(nameof(user));

            if(value<1||value>5) 
                throw new ArgumentOutOfRangeException(nameof(value));

            /*Check on twise Rate?*/

            _ratings.Add(new Rating(value, user));
        }
    }
}
