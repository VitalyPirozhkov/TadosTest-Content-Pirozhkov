using Api.Requests.Abstractions;
using Api.Requests.Hierarchic.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Transactions.Behaviors;
using System;
using System.Threading.Tasks;
namespace CitiesBlog.Controllers.User
{
    using Actions.Create;
    using Actions.Get;
    using Actions.GetList;
    using AspnetCore.ApiControllers.Extensions;

    [ApiController]
    [Route("api/user")]
    public class UserController : CitiesBlogApiControllerBase
    {
        public UserController(IAsyncRequestBuilder asyncRequestBuilder,
            IAsyncHierarchicRequestBuilder asyncHierarchicRequestBuilder,
            IExpectCommit commitPerformer)
            : base(
                asyncRequestBuilder,
                asyncHierarchicRequestBuilder,
                commitPerformer)
        {
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(typeof(UserCreateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Create(UserCreateRequest request) =>
            this.RequestAsync().For<UserCreateResponse>().With(request);

        [HttpPost]
        [Route("get")]
        [ProducesResponseType(typeof(UserGetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Get(UserGetRequest request) =>
            this.RequestAsync().For<UserGetResponse>().With(request);

        [HttpPost]
        [Route("getList")]
        [ProducesResponseType(typeof(UserGetListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Get(UserGetListRequest request) =>
            this.RequestAsync().For<UserGetListResponse>().With(request);
    }
}