using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Entity
{
    public class City : IEntity
    {
        protected internal City(string name, Country country) 
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            Country = country ?? throw new ArgumentNullException(nameof(country));
            Name = name;
        }

        public City(long id, string name, Country country) : this(name, country)
        {
            Id = id;
        }

        public long Id { get; set; }

        public string Name { get; init; }

        public Country Country { get; init; }
    }
}
