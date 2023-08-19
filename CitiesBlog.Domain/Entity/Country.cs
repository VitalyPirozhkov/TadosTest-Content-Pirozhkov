using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;

namespace CitiesBlog.Domain.Entity
{
    public class Country : IEntity
    {
        [Obsolete("Only for reflection", true)]
        public Country() { }

        protected internal Country(string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            Name = name;
        }

        public Country(long id, string name) : this(name)
        {
            Id = id;
        }

        public virtual long Id { get; set; }

        public virtual string Name { get; init; }
    }
}
