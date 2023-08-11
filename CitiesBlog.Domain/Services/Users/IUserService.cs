using CitiesBlog.Domain.Entity;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Services.Users
{
    public interface IUserService : IDomainService
    {
        Task<User> CreateUserAsync(string login, City city);
    }
}
