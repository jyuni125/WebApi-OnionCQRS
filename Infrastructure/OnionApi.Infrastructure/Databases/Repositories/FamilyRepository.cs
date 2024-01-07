using AutoMapper;
using AutoMapper.QueryableExtensions;
using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OnionApi.Application.Commands.Family;
using OnionApi.Domain.Contracts.Repositories;
using OnionApi.Domain.Entities;
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
        private readonly IMapper _mapper;

        public FamilyRepository(FamilyDBContext db) : base(db)
        {
        }

        public FamilyRepository(FamilyDBContext db,ILogger<Family> logger,IMapper mapper) : base(db,logger,mapper)
        {
            _mapper = mapper;   
        }

        public async Task<Guid> Create(T t)
        {
         

            try
            {

                //  await _table.AddAsync(t);
                //  await _db.SaveChangesAsync();

                var entity = _mapper.Map<Family>(t);

                _db.Families.Add(entity);
                await _db.SaveChangesAsync();


                return entity.Id;
                            
                

            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Create Repository} All fucntion error", typeof(BaseRepository<T>));
                throw;
            }
        }

        public async Task<int> Delete(Guid id)
        {
           

            try
            {
                /*
                var data = await GetOne(id);

                if (data != null)
                {
                    _table.Remove(data);
                    await _db.SaveChangesAsync();
                }
                */

                /*

                var entity = await GetOne(id);

                var returndata = _db.Families.Remove(_mapper.Map<Family>(entity));

                await _db.SaveChangesAsync();
                */


                await _db.Families
                          .Where(data => data.Id == id)
                          .ExecuteDeleteAsync();

                return 1;

            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Delete Repository} All fucntion error", typeof(BaseRepository<T>));
                throw;
            }
        }

   

        public async Task<IEnumerable<T>> getByLastName(string lastname)
        {


            try
            {

                /*
               return await _table
             .Where(n => n.LastName == Lastname)
             .ToListAsync();

               */

                return await _db.Families
                            .Where(data => data.LastName == lastname)
                            .ProjectTo<T>(_mapper.ConfigurationProvider)
                            .ToListAsync();

            }
            catch (Exception e)
            {
                _logger.LogError(e, "{GetFromId Repository} All fucntion error", typeof(BaseRepository<T>));
                throw;
            }
        }


        public async Task<int> Update(Guid id, object model)
        {
            

            try
            {
                /*
                var data = await GetOne(t.Id);

                if (data != null)
                {
                    _db.Entry(data).CurrentValues.SetValues(t);
                    await _db.SaveChangesAsync();
                }
                */

                /*
                var data = await GetOne(t.Id);

                var returndata =_db.Families.Update(_mapper.Map<Family>(data));

                await _db.SaveChangesAsync();

                */


                var data = await GetOne(id);

                var newdata = (UpdateFamilyCommand)model;
                var entitydata = _mapper.Map<Family>(data);
                

                if (newdata.status.HasValue) entitydata.status = (int)newdata.status;
                if (!newdata.FirstName.IsNullOrEmpty()) entitydata.FirstName = (string)newdata.FirstName;
                if (!newdata.LastName.IsNullOrEmpty()) entitydata.LastName = (string)newdata.LastName;
                if (newdata.Gender.HasValue) entitydata.Gender = (short)newdata.Gender;


                //var returndata = _mapper.Map<Family>(model);
                
                await _db.Families
                        .Where(model => model.Id ==id)
                        .ExecuteUpdateAsync(setters => setters
                                .SetProperty(d => d.Id, entitydata.Id)
                                .SetProperty(d => d.UpdateDate, entitydata.UpdateDate)
                                .SetProperty(d => d.AddedDate, entitydata.AddedDate)
                                .SetProperty(d => d.FirstName, entitydata.FirstName)
                                .SetProperty(d => d.LastName, entitydata.LastName)
                                .SetProperty(d => d.status, entitydata.status)
                                .SetProperty(d => d.Gender, entitydata.Gender)
                                );

                

               // _db.Entry(_mapper.Map<Family>(data)).CurrentValues.SetValues(model);
               // await _db.SaveChangesAsync();
                return 1;

            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Update Repository} All fucntion error", typeof(BaseRepository<T>));
                throw;
            }
        }
    }
}
