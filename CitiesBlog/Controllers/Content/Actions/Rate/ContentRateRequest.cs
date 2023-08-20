using Api.Requests.Abstractions;

namespace CitiesBlog.Controllers.Content.Actions.Rate
{
    public record ContentRateRequest : IRequest
    {
        public long UserId { get; set; }

        public long ContentId { get; set; }

        public int Value { get; set; }
    }
}