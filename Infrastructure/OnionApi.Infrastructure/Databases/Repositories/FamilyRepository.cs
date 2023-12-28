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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnionApi.Infrastructure.Databases.Repositories
{
    public class FamilyRepository<T> : BaseRepository<T>, IFamilyRepository<T>
        where T:class,IBaseModel
    {
        public FamilyRepository(FamilyDBContext db,ILogger<T> logger) : base(db,logger)
        {
        }

        public async Task Create(T t)
        {
         

            try
            {

                await _table.AddAsync(t);
                await _db.SaveChangesAsync();

            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Create Repository} All fucntion error", typeof(BaseRepository<T>));
                throw;
            }
        }

        public async Task Delete(Guid id)
        {
           

            try
            {
                var data = await GetOne(id);

                if (data != null)
                {
                    _table.Remove(data);
                    await _db.SaveChangesAsync();
                }


            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Delete Repository} All fucntion error", typeof(BaseRepository<T>));
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetLastName(string Lastname)
        {

       

            try
            {

                return await _table
              .Where(n => n.LastName == Lastname)
              .ToListAsync();

            }
            catch (Exception e)
            {
                _logger.LogError(e, "{GetFromLastName Repository} All fucntion error", typeof(BaseRepository<T>));
                throw;
            }
        }

        public async Task Update(T t)
        {
            

            try
            {

                var data = await GetOne(t.Id);

                if (data != null)
                {
                    _db.Entry(data).CurrentValues.SetValues(t);
                    await _db.SaveChangesAsync();
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Update Repository} All fucntion error", typeof(BaseRepository<T>));
                throw;
            }
        }
    }
}
