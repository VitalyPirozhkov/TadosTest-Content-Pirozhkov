using CitiesBlog.Domain.Entity;
using Commands.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Commands.Contexts
{
    public class CreateGalleryCommandContext : ICommandContext
    {
        public CreateGalleryCommandContext(Gallery gallery) 
        {
            Gallery= gallery ?? throw new ArgumentNullException(nameof(gallery));
        }

        Gallery Gallery { get;}
    }
}
