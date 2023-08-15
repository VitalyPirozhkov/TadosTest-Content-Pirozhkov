using CitiesBlog.Domain.Entity;
using Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Commands.Contexts
{
    public class CreateCityCommandContext : ICommandContext
    {
        public CreateCityCommandContext(City city) 
        {
            City= city ?? throw new ArgumentNullException(nameof(city));
        }

        public City City { get;}
    }
}
