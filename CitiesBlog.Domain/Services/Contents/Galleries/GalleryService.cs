using CitiesBlog.Domain.Commands.Contexts;
using CitiesBlog.Domain.Entity;
using CitiesBlog.Domain.Services.Contents;
using Commands.Abstractions;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Services.Contents.Galleries
{
    public class GalleryService : ContentService, IGalleryService
    {
        private readonly IAsyncCommandBuilder _commandBuilder;


        public GalleryService(IAsyncCommandBuilder commandBuilder)
        {
            _commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder));
        }
        public async Task<Gallery> CreateGalleryAsync(string name, User creator, string cover,
            IEnumerable<string> images, CancellationToken cancellationToken = default)
        {
            Gallery gallery = new Gallery(name, creator, cover, images);

            await _commandBuilder.ExecuteAsync(new CreateGalleryCommandContext(gallery), cancellationToken);

            return gallery;
        }
    }
}
