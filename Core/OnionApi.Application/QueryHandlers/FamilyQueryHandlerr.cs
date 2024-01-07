using AutoMapper;
using MediatR;
using OnionApi.Application.Queries.Family;
using OnionApi.Application.ViewModel;
using OnionApi.Domain.Contracts.Repositories;
using OnionApi.Domain.Entities;
using OnionApi.Domain.Enumerations;
using OnionApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Application.QueryHandlers
{
    public class FamilyQueryHandlerr : IRequestHandler<GetAllFamilyQuery2, IEnumerable<FamilyVIewModel2>>,
                                       IRequestHandler<GetFamilyByIdQuery,FamilyVIewModel2>,
                                       IRequestHandler<GetAllFamilyByLastNameQuery, IEnumerable<FamilyVIewModel2>>
    {
        private readonly IMapper _mapper;
        private readonly IFamilyRepository<FamilyModel> _familyRepository;

        public FamilyQueryHandlerr(IMapper mapper, IFamilyRepository<FamilyModel> familyRepository)
        {
            _mapper = mapper;
            _familyRepository = familyRepository;
        }

        public async Task<IEnumerable<FamilyVIewModel2>> Handle(GetAllFamilyQuery2 request, CancellationToken cancellationToken)
        {
            var data = await _familyRepository.GetAll();

            /*

            var finalreturndata = data.Select(data => new FamilyVIewModel2
            {
                UpdateDate = data.UpdateDate,
                AddedDate = data.AddedDate,
                FirstName = data.FirstName,
                Gender = (data.Gender).ToString(),
                Id = data.Id,
                LastName = data.LastName,
                status = data.status
            }).ToList();

            */

            return _mapper.Map<IEnumerable<FamilyVIewModel2>>(data);

           // return finalreturndata;
        }

        public async Task<FamilyVIewModel2> Handle(GetFamilyByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _familyRepository.GetOne(request.Id);

            return _mapper.Map<FamilyVIewModel2>(data);
        }

        public async Task<IEnumerable<FamilyVIewModel2>> Handle(GetAllFamilyByLastNameQuery request, CancellationToken cancellationToken)
        {
            var data = await _familyRepository.getByLastName(request.Lastname);

            return _mapper.Map<IEnumerable<FamilyVIewModel2>>(data);
        }
    }
}
