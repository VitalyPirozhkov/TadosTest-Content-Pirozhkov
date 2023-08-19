using Api.Requests.Abstractions;
using CitiesBlog.Controllers.City.Actions.Create;
using CitiesBlog.Domain.Criteria;
using CitiesBlog.Domain.Services.Cities;
using CitiesBlog.Domain.Services.Users;
using Queries.Abstractions;
using System;
using System.Threading.Tasks;

namespace CitiesBlog.Controllers.User.Actions.Create
{
    public class UserCreateRequestHandler : IAsyncRequestHandler<UserCreateRequest, UserCreateResponse>
    {
        private readonly IAsyncQueryBuilder _asyncQueryBuilder;
        private readonly IUserService _userService;

        public UserCreateRequestHandler(IUserService userService, IAsyncQueryBuilder asyncQueryBuilder)
        {
            _asyncQueryBuilder = asyncQueryBuilder ?? throw new ArgumentNullException(nameof(asyncQueryBuilder));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<UserCreateResponse> ExecuteAsync(UserCreateRequest request)
        {
            var city = await _asyncQueryBuilder.FindByIdAsync<Domain.Entity.City>(request.CityId);
            var user = await _userService.CreateUserAsync(
                login: request.Login,
                city: city);
            return new UserCreateResponse(user.Id);
        }
    }
}
