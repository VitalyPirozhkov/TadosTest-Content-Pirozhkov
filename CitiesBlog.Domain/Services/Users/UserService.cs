using CitiesBlog.Domain.Entity;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Services.Users
{
    internal class UserService : IUserService
    {
        public async Task<User> CreateUserAsync(string login, City city)
        {
            await CheckIsUserNameExistAsync(login);

            /*Check is City exist?*/

            return new User(login, city);
        }

        private async Task CheckIsUserNameExistAsync(string login)
        {
            throw new NotImplementedException();
        }
    }
}
