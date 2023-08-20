using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Entity
{
    public class Images : IEntity
    {
        [Obsolete("Only for reflection", true)]
        public Images() { }

        protected internal Images(string reference) 
        {
            Reference= reference;
        }

        public Images(long id, string reference)
        {
            Id = id;
            Reference = reference;
        }

        public virtual long Id { get; init; }

        public virtual string Reference { get; init; }
    }
}
