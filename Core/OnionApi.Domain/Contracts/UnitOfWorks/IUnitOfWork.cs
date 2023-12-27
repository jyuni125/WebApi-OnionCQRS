using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Domain.Contracts.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
    }
}
