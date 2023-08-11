using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Database.Abstractions
{
    public interface IDbTransactionProvider
    {
        bool IsInitialized { get; }

        Task<DbTransaction> GetCurrentTransactionAsync(CancellationToken cancellationToken = default);
    }
}
