using CitiesBlog.Domain.Entity;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Services.Raitings
{
    public interface IRatingService : IDomainService
    {
        Task RateAsync(Content content, User user, int value, CancellationToken cancellationToken = default);
    }
}
