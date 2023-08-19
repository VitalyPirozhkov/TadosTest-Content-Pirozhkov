using CitiesBlog.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Entity
{
    public class Gallery: Content
    {
        private readonly ISet<string> _images = new HashSet<string>();

        [Obsolete("Only for reflection", true)]
        public Gallery() { }

        protected internal Gallery(string name, User creator, string cover, IEnumerable<string> images)
             : base(name, Enums.ContentType.Gallery, creator)
        {
            if (string.IsNullOrWhiteSpace(cover))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(cover));
            if(images==null)
                throw new ArgumentNullException(nameof(images));
            Cover = cover;
            foreach (var image in images)
            {
                _images.Add(image);
            }
        }

        public Gallery(long id, string name, User creator, string cover, IEnumerable<string> images, IEnumerable<Rating> ratings)
            : base(id, name, Enums.ContentType.Gallery, creator, ratings)
        {
            if (string.IsNullOrWhiteSpace(cover))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(cover));
            if (images == null)
                throw new ArgumentNullException(nameof(images));
            Cover = cover;
            foreach (var image in images)
            {
                _images.Add(image);
            }
        }

        public virtual string Cover { get; init; } 

        public virtual IEnumerable<string> Images => _images.AsEnumerable();
    }
}
