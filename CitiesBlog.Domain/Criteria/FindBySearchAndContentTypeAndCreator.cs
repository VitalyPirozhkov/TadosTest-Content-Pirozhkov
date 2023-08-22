using CitiesBlog.Domain.Enums;
using Queries.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesBlog.Domain.Criteria
{
    public class FindBySearchAndContentTypeAndCreator : ICriterion
    {
        public FindBySearchAndContentTypeAndCreator(string search, ContentType? contentType, long userId)
        {
            Search = search;
            ContentType = contentType;
            UserId = userId;
        }

        public string Search { get; }
        public ContentType? ContentType { get; }
        public long UserId { get; }
    }
}
