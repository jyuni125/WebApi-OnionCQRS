using Microsoft.EntityFrameworkCore;
using OnionApi.Domain.Contracts;
using OnionApi.Domain.Models;
using OnionApi.Infrastructure.Databases.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Infrastructure.Databases.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class,IBaseModel
    {
        protected readonly FamilyDBContext _db;
        protected readonly DbSet<T> _table;


        public BaseRepository(FamilyDBContext db)
        {
            _db = db;
            _table = db.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetOne(Guid id)
        {
            return await _table.FindAsync(id);
        }
    }
}
