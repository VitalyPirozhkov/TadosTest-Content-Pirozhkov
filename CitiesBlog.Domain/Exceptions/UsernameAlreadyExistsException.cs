using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Exceptions
{
    internal class UsernameAlreadyExistsException : Exception, IDomainException
    {
        private const string DefaultMessage = "The user with the selected name already exists";

        public UsernameAlreadyExistsException() : base(DefaultMessage) 
        { 

        }
    }
}
