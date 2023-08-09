using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Exceptions
{
    public class CountryAlreadyExistsException : Exception, IDomainException
    {
        private const string DefaultMessage = "A country with the given name already exists";

        public CountryAlreadyExistsException() : base(DefaultMessage)
        {

        }
    }
}
