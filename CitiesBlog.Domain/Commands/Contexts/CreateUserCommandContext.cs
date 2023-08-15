using CitiesBlog.Domain.Entity;
using CitiesBlog.Domain.ValueObjects;
using Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Commands.Contexts
{
    public class CreateUserCommandContext : ICommandContext
    {
        public CreateUserCommandContext(User user) 
        {
            User= user ?? throw new ArgumentNullException(nameof(user));
        }

        User User { get;}
    }
}
