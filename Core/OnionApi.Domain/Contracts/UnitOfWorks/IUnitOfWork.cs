using OnionApi.Domain.Common;
using OnionApi.Domain.Contracts.Repositories;
using OnionApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Domain.Contracts.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IFamilyRepository<T> GetReadAndWriteRepository<T>() where T : class, IBaseEntity, IBaseModel, new();

        Task<int> SaveAsync();
        int Save();
    }
}
