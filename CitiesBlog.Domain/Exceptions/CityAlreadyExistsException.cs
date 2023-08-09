using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Exceptions
{
    internal class CityAlreadyExistsException : Exception, IDomainException
    {
        private const string DefaultMessage = "A city with the given name already exists in the selected country";

        public CityAlreadyExistsException() :base(DefaultMessage) 
        { 

        }
    }
}
