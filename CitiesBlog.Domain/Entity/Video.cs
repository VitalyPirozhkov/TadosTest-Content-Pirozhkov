using CitiesBlog.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Entity
{
    public class Video : Content
    {
        [Obsolete("Only for reflection", true)]
        public Video() { }

        protected internal Video(string name, User creator, string reference)
             : base(name, Enums.ContentType.Video, creator)
        {
            if (string.IsNullOrWhiteSpace(reference))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(reference));
            Reference = reference;
        }

        public Video(long id, string name, User creator, string reference, IEnumerable<Rating> ratings)
            : base(id, name, Enums.ContentType.Video, creator, ratings)
        {
            if (string.IsNullOrWhiteSpace(reference))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(reference));
            Reference = reference;
        }

        public string Reference { get; init; }
    }
}
