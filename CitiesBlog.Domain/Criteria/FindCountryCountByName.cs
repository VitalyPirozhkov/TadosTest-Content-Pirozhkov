using Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Criteria
{
    public class FindCountryCountByName : ICriterion
    {
        public FindCountryCountByName(string name)
        {
            Name= name;
        }

        public string Name { get;}
    }
}
