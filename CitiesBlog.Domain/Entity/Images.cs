using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Entity
{
    public class Image : IEntity
    {
        [Obsolete("Only for reflection", true)]
        public Image() { }

        protected internal Image(string reference) 
        {
            Reference= reference;
        }

        public Image(long id, string reference)
        {
            Id = id;
            Reference = reference;
        }

        public virtual long Id { get; init; }

        public virtual string Reference { get; init; }
    }
}
