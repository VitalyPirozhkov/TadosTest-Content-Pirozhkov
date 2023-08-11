using CitiesBlog.Domain.Entity;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Services.Cities
{
    public interface ICityService: IDomainService
    {
        Task<City> CreateCityAsync(string name, Country country);
    }
}
