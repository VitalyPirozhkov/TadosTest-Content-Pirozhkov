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

namespace CitiesBlog.Domain.Services.Contents.Videos
{
    public class VideoService : ContentService, IVideoService
    {
        private readonly IAsyncCommandBuilder _commandBuilder;


        public VideoService(IAsyncCommandBuilder commandBuilder)
        {
            _commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder));
        }

        public async Task<Video> CreateVideoAsync(string name, User creator, string reference,
            CancellationToken cancellationToken = default)
        {
            Video video = new Video(name, creator, reference);

            //await _commandBuilder.ExecuteAsync(new CreateVideoCommandContext(video), cancellationToken);
            await _commandBuilder.CreateAsync(video, cancellationToken);

            return video;
        }
    }
}
