using AutoMapper;
using MediatR;
using OnionApi.Core.Queries.Family;
using OnionApi.Core.ViewModel;
using OnionApi.Domain.Contracts.UnitOfWorks;
using OnionApi.Domain.Entities;
using OnionApi.Infrastructure.Databases.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Core.QueryHandlers
{
    public class FamilyQueryHandler : IRequestHandler<GetAllFamilyQuery, IEnumerable<FamilyVIewModel>>
    {

        protected readonly FamilyRepository<Family> _repo;
        private readonly IUnitOfWork _uniOfWork;
        private readonly IMapper _mapper;

        public FamilyQueryHandler(FamilyRepository<Family> repo, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _repo = repo;
            _uniOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FamilyVIewModel>> Handle(GetAllFamilyQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Family> data= await _repo.GetAll();

            var data2 = await _uniOfWork.GetReadAndWriteRepository<Family>().GetAll();
            /*
            List<FamilyVIewModel> response = new();

            foreach(var mydata in data2)
            {
                response.Add(new FamilyVIewModel
                {
                    Id = mydata.Id,
                    AddedDate = mydata.AddedDate,
                    FirstName = mydata.FirstName,
                    Gender = mydata.Gender,
                    LastName = mydata.LastName,
                    status = mydata.status,
                    UpdateDate = mydata.UpdateDate
                });
            } 

            */
            var returnData = _mapper.Map<IEnumerable<FamilyVIewModel>>(data);

            //return response;
            return returnData;
        }
    }
}
