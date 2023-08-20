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
        private readonly ISet<Images> _images = new HashSet<Images>();

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
                Images objImage = new Images(image);
                _images.Add(objImage);
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
                Images objImage = new Images(image);
                _images.Add(objImage);
            }
        }

        public virtual string Cover { get; init; } 

        public virtual IEnumerable<Images> Images => _images.AsEnumerable();
    }
}
