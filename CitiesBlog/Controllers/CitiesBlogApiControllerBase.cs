using Api.Requests.Abstractions;
using Api.Requests.Hierarchic.Abstractions;
using AspnetCore.ApiControllers.Abstractions;
using Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Persistence.Transactions.Behaviors;
using System;

namespace CitiesBlog.Controllers
{
    public class CitiesBlogApiControllerBase : ApiControllerBase
    {
        public CitiesBlogApiControllerBase(
            IAsyncRequestBuilder asyncRequestBuilder,
            IAsyncHierarchicRequestBuilder asyncHierarchicRequestBuilder,
            IExpectCommit commitPerformer)
            : base(
                asyncRequestBuilder,
                asyncHierarchicRequestBuilder,
                commitPerformer)
        {
        }

        public override Func<Exception, IActionResult> Fail => ProcessFail;



        private static IActionResult ProcessFail(Exception exception)
        {
            if (exception is IDomainException)
                return new BadRequestObjectResult(new
                {
                    Type = exception.GetType().Name,
                    Message = exception.Message
                });

            throw exception;
        }
    }
}
