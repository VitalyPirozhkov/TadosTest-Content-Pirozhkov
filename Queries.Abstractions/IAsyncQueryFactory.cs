using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries.Abstractions
{
    public interface IAsyncQueryFactory
    {
        IAsyncQuery<TCriterion, TResult> Create<TCriterion, TResult>() where TCriterion : ICriterion;
    }
}
