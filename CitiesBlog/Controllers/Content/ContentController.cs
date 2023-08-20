using Api.Requests.Abstractions;
using Api.Requests.Hierarchic.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Transactions.Behaviors;
using System;
using System.Threading.Tasks;

namespace CitiesBlog.Controllers.Content
{

    using Actions.Create;
    using Actions.Get;
    using Actions.GetList;
    using Actions.Rate;
    using AspnetCore.ApiControllers.Extensions;

    [ApiController]
    [Route("api/content")]
    public class ContentController : CitiesBlogApiControllerBase
    {
        public ContentController(IAsyncRequestBuilder asyncRequestBuilder,
            IAsyncHierarchicRequestBuilder asyncHierarchicRequestBuilder,
            IExpectCommit commitPerformer)
            : base(
                asyncRequestBuilder,
                asyncHierarchicRequestBuilder,
                commitPerformer)
        {
        }
    
        [HttpPost]
        [Route("createArticle")]
        [ProducesResponseType(typeof(ContentCreateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> CreateArticle(ContentCreateArticleRequest request) =>
            this.RequestAsync().For<ContentCreateResponse>().With(request);

        [HttpPost]
        [Route("createVideo")]
        [ProducesResponseType(typeof(ContentCreateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> CreateVideo(ContentCreateVideoRequest request) =>
            this.RequestAsync().For<ContentCreateResponse>().With(request);

        [HttpPost]
        [Route("createGallery")]
        [ProducesResponseType(typeof(ContentCreateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> CreateGallery(ContentCreateGalleryRequest request) =>
            this.RequestAsync().For<ContentCreateResponse>().With(request);
        

        [HttpPost]
        [Route("rate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Rate(ContentRateRequest request) => 
            this.RequestAsync(request);
        
        [HttpPost]
        [Route("get")]
        [ProducesResponseType(typeof(ContentGetResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Get(ContentGetRequest request) => 
            this.RequestAsync().For<ContentGetResponse>().With(request);

        [HttpPost]
        [Route("getList")]
        [ProducesResponseType(typeof(ContentGetListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<IActionResult> Get(ContentGetListRequest request) => 
            this.RequestAsync().For<ContentGetListResponse>().With(request);
    }
}