using AutoMapper;
using OnionApi.Application.Commands.Family;
using OnionApi.Application.DTOs.Family;
using OnionApi.Application.Queries.Family;
using OnionApi.Application.ViewModel;
using OnionApi.Domain.Entities;
using OnionApi.Domain.Models;
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

            //CREATE
            CreateMap<CreateFamilyDTO, CreateFamilyCommand>();
            CreateMap<CreateFamilyCommand, FamilyModel>()
                    .ConstructUsing(data => new FamilyModel(data.status, data.FirstName, data.LastName, data.Gender));
            CreateMap<FamilyModel, Family>()
                    .ForMember(data => data.Gender,
                                    genderInside => genderInside.MapFrom(
                                        genderData => (short)genderData.Gender
                                        ));
          
            // dto -> command   (baseController)
            // command -> model (ComamndHandler)
            // model -> entity  (Repository)
            // RETURN ID



            //UPDATE
            CreateMap<UpdateFamilyDTO, UpdateFamilyCommand>();
            //dto -> command    (baseController)
            //RETURN null




            //DELETE
            CreateMap<DeleteFamilyDTO, DeleteFamilyCommand>();

            //dto -> command    (baseController)
            //RETURN null


            //READ
            CreateMap<Family, FamilyModel>()
                  .ConstructUsing(data => new FamilyModel(data.Id, data.FirstName, data.LastName, data.Gender));
            CreateMap<FamilyModel, FamilyVIewModel2>();

            //entity -> Model   (Repository)
            //Model -> ViewModel(QueryHandler)

        }
    }
}
