using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CitiesBlog.Domain.Entity
{
    public class User: IEntity
    {
        [Obsolete("Only for reflection", true)]
        public User() { }

        protected internal User(string login, City city) 
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(login));
            City = city ?? throw new ArgumentNullException(nameof(city));
            Login = login;
        }

        public User(long id, string login, City city) : this(login, city)
        {
            Id = id;
        }

        public virtual long Id { get; set; }

        public virtual string Login { get; init; }

        public virtual City City { get; init; }
    }
}
