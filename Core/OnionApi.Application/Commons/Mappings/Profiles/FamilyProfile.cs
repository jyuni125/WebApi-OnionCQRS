using AutoMapper;
using OnionApi.Application.Queries.Family;
using OnionApi.Application.ViewModel;
using OnionApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Application.Commons.Mappings.Profiles
{
    public class FamilyProfile : Profile
    {
        public FamilyProfile()
        {

            CreateMap<Family, FamilyVIewModel2>();
           // CreateMap<FamilyVIewModel2, GetAllFamilyQuery2>();
        }
    }
}
