using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnionApi.Domain.Contracts.Repositories;
using OnionApi.Domain.Entities;
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
        //protected readonly DbSet<T> _table;
        public readonly ILogger<Family> _logger;
        private readonly IMapper _mapper;


        public BaseRepository(FamilyDBContext db)
        {
            _db = db;
           // _table = db.Set<T>();
           
        }

        public BaseRepository(FamilyDBContext db, ILogger<Family> logger, IMapper mapper)
        {
            _db = db;
            //_table = db.Set<T>();
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            

            try
            {
                _logger.LogInformation("GET ALL REPOSITORY WORKED!");
                //return await _table.ToListAsync();


                return await _db.Families
                            .ProjectTo<T>(_mapper.ConfigurationProvider)
                            .ToListAsync();

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
                _logger.LogInformation("GET BY ID REPOSITORY WORKED!");
                // return await _table.FindAsync(id);

                return await _db.Families
                            .Where(data => data.Id == id)
                            .ProjectTo<T>(_mapper.ConfigurationProvider)
                            .FirstOrDefaultAsync();

            }
            catch (Exception e)
            {
                _logger.LogError(e, "{GetFromId Repository} All fucntion error", typeof(BaseRepository<T>));
                throw;
            }
        }
    }
}
