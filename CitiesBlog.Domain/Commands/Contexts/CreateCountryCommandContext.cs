using CitiesBlog.Domain.Entity;
using Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Commands.Contexts
{
    public class CreateCountryCommandContext : ICommandContext
    {
        public CreateCountryCommandContext(Country country) 
        {
            Country = country ?? throw new ArgumentNullException(nameof(country));
        }

        public Country Country { get; }
    }
}
