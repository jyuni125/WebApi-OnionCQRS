using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnionApi.Domain.Contracts.Repositories;
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
        public readonly ILogger<T> _logger;

        public BaseRepository(FamilyDBContext db, ILogger<T> logger)
        {
            _db = db;
            _table = db.Set<T>();
            _logger = logger;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            

            try
            {
                return await _table.ToListAsync();


            }
            catch (Exception e)
            {
                _logger.LogError(e, "{GetALl Repository} All fucntion error", typeof(BaseRepository<T>));
                throw;
            }
        }

        public async Task<T> GetOne(Guid id)
        {
           

            try
            {
                return await _table.FindAsync(id);


            }
            catch (Exception e)
            {
                _logger.LogError(e, "{GetFromId Repository} All fucntion error", typeof(BaseRepository<T>));
                throw;
            }
        }
    }
}
