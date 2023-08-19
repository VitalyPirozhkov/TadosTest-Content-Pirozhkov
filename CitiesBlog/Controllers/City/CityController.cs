using Api.Requests.Abstractions;
using Api.Requests.Hierarchic.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Transactions.Behaviors;
using System;
using System.Threading.Tasks;
namespace CitiesBlog.Controllers.City
{
    using Actions.Create;
    using Actions.Get;
    using Actions.GetList;
    using AspnetCore.ApiControllers.Extensions;

    [ApiController]
    [Route("api/city")]
    public class CityController : CitiesBlogApiControllerBase
    {
        public CityController(IAsyncRequestBuilder asyncRequestBuilder,
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
        [ProducesResponseType(typeof(CityCreateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Create(CityCreateRequest request) =>
            this.RequestAsync().For<CityCreateResponse>().With(request);


        [HttpPost]
        [Route("get")]
        [ProducesResponseType(typeof(CityGetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Get(CityGetRequest request) => 
            this.RequestAsync().For<CityGetResponse>().With(request);

        [HttpPost]
        [Route("getList")]
        [ProducesResponseType(typeof(CityGetListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Get(CityGetListRequest request) =>
            this.RequestAsync().For<CityGetListResponse>().With(request);
    }
}