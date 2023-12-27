using Microsoft.EntityFrameworkCore;
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
        public FamilyRepository(FamilyDBContext db) : base(db)
        {
        }

        public async Task Create(T t)
        {
            await _table.AddAsync(t);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var data = await GetOne(id);

            if (data != null)
            {
                _table.Remove(data);
                await _db.SaveChangesAsync();
            }


        }

        public async Task<IEnumerable<T>> GetLastName(string Lastname)
        {

            return await _table
                   .Where(n => n.LastName == Lastname)
                   .ToListAsync();
        }

        public async Task Update(T t)
        {
            var data = await GetOne(t.Id);

            if (data != null)
            {
                _db.Entry(data).CurrentValues.SetValues(t);
                await _db.SaveChangesAsync();
            }
        }
    }
}
