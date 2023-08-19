using System;
using System.Threading.Tasks;
using Api.Requests.Abstractions;
using Api.Requests.Hierarchic.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Transactions.Behaviors;
namespace CitiesBlog.Controllers.Country
{
    using Actions.Create;
    using Actions.Get;
    using Actions.GetList;
    using AspnetCore.ApiControllers.Extensions;

    [ApiController]
    [Route("api/country")]
    public class CountryController : CitiesBlogApiControllerBase
    {
        public CountryController(IAsyncRequestBuilder asyncRequestBuilder,
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
        [ProducesResponseType(typeof(CountryCreateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Create(CountryCreateRequest request) =>
            this.RequestAsync().For<CountryCreateResponse>().With(request);


        [HttpPost]
        [Route("get")]
        [ProducesResponseType(typeof(CountryGetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Get(CountryGetRequest request) =>
            this.RequestAsync().For<CountryGetResponse>().With(request);

        [HttpPost]
        [Route("getList")]
        [ProducesResponseType(typeof(CountryGetListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Get(CountryGetListRequest request) =>
            this.RequestAsync().For<CountryGetListResponse>().With(request);
    }
}