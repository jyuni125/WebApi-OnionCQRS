using AutoMapper;
using MediatR;
using OnionApi.Application.Queries.Family;
using OnionApi.Application.ViewModel;
using OnionApi.Domain.Contracts.Repositories;
using OnionApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Application.QueryHandlers
{
    public class FamilyQueryHandlerr : IRequestHandler<GetAllFamilyQuery2, IEnumerable<FamilyVIewModel2>>
    {
        private readonly IMapper _mapper;
        private readonly IFamilyRepository<Family> _familyRepository;

        public FamilyQueryHandlerr(IMapper mapper, IFamilyRepository<Family> familyRepository)
        {
            _mapper = mapper;
            _familyRepository = familyRepository;
        }

        public async Task<IEnumerable<FamilyVIewModel2>> Handle(GetAllFamilyQuery2 request, CancellationToken cancellationToken)
        {
            IEnumerable<Family> data = await _familyRepository.GetAll();


            var finalreturndata = data.Select(data => new FamilyVIewModel2
            {
                UpdateDate = data.UpdateDate,
                AddedDate = data.AddedDate,
                FirstName = data.FirstName,
                Gender = data.Gender,
                Id = data.Id,
                LastName = data.LastName,
                status = data.status
            }).ToList();



            return _mapper.Map<IEnumerable<FamilyVIewModel2>>(data);

            //return finalreturndata;
        }
    }
}
