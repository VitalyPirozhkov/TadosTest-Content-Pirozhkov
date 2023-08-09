using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Exceptions
{
    public class MultipleUserRateException : Exception, IDomainException
    {
        private const string DefaultMessage = "User can not rate multiple times";

        public MultipleUserRateException()
            :base(DefaultMessage)
        { 

        }
    }
}
