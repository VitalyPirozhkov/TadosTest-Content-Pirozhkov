using CitiesBlog.Domain.Entity;
using Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Criteria
{
    public class FindCityCountByNameAndCountry : ICriterion
    {
        public FindCityCountByNameAndCountry(string name, Country country) 
        { 
            Country = country ?? throw new ArgumentNullException(nameof(country));
            Name = name;
        }

        public string Name { get;}
        public Country Country { get;}
    }
}
