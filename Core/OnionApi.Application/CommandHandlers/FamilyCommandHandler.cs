using AutoMapper;
using MediatR;
using OnionApi.Application.Commands.Family;
using OnionApi.Domain.Contracts.Repositories;
using OnionApi.Domain.Entities;
using OnionApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Application.CommandHandlers
{
    public class FamilyCommandHandler : IRequestHandler<CreateFamilyCommand, Guid>
                                        , IRequestHandler<UpdateFamilyCommand,int>
                                        , IRequestHandler<DeleteFamilyCommand,int>
    {
        private readonly IMapper _mapper;
        private readonly IFamilyRepository<FamilyModel> _repo;

        public FamilyCommandHandler(IMapper mapper,IFamilyRepository<FamilyModel> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }


        public async Task<Guid> Handle(CreateFamilyCommand request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<FamilyModel>(request);

            return await _repo.Create(data);
        }

        public async Task<int> Handle(UpdateFamilyCommand request, CancellationToken cancellationToken)
        {
            /*
            //we get the data and have data type of "MODEL"
            var dtoData =await _repo.GetOne(request.Id);

            //convert MODEL to ENTITY so we can set the data
            var dtoDatatoEntity = _mapper.Map<Family>(dtoData);

                //if have value set the data 
                if (request.status.HasValue) dtoDatatoEntity.status = (int)request.status;
                if (request.FirstName!=null) dtoDatatoEntity.FirstName = (string)request.FirstName;
                if (request.LastName!=null) dtoDatatoEntity.LastName = (string)request.LastName;
                if (request.Gender.HasValue) dtoDatatoEntity.Gender = (short)request.Gender;

            
        
            //convert Entity to MODEL 
            var entityToDto = _mapper.Map<FamilyModel>(dtoDatatoEntity);

            await _repo.Update(entityToDto);

            */


            return await _repo.Update(request.Id, request);
        }

        public async Task<int> Handle(DeleteFamilyCommand request, CancellationToken cancellationToken)
        {
           return await _repo.Delete(request.Id);
        }
    }
}
