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
    public class CreateVideoCommandContext : ICommandContext
    {
        public CreateVideoCommandContext(Video video) 
        {
            Video = video ?? throw new ArgumentNullException(nameof(video));
        }

        public Video Video { get;}
    }
}
