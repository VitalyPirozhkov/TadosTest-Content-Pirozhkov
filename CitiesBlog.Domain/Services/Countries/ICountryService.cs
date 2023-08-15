using CitiesBlog.Domain.Entity;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Services.Countries
{
    public interface ICountryService : IDomainService
    {
        Task<Country> CreateCountryAsync(string name, CancellationToken cancellationToken = default);
    }
}
