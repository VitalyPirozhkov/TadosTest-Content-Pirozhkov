using Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Criteria
{
    public class FindBySearch : ICriterion
    {
        public FindBySearch(string search) 
        {
            Search= search;
        }

        public string Search { get; }
    }
}
