using Microsoft.Extensions.Logging;
using OnionApi.Domain.Contracts.Repositories;
using OnionApi.Domain.Contracts.UnitOfWorks;
using OnionApi.Infrastructure.Databases.Context;
using OnionApi.Infrastructure.Databases.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Infrastructure.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {   
        private readonly FamilyDBContext _db;

        public UnitOfWork(FamilyDBContext db)
        {
            _db = db;
        }

        public async ValueTask DisposeAsync()
        {
            await _db.DisposeAsync();
        }

        public int Save()
        {
           return _db.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }

        IFamilyRepository<T> IUnitOfWork.GetReadAndWriteRepository<T>()
        {
           return new FamilyRepository<T>(_db);
        }
    }
} 
