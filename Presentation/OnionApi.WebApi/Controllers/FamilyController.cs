using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApi.Application.Commands.Family;
using OnionApi.Application.DTOs.Family;
using OnionApi.Application.Queries.Family;
using OnionApi.Application.ViewModel;
using OnionApi.Domain.Contracts.Repositories;
using OnionApi.Domain.Entities;
using OnionApi.WebApi.Common;

namespace OnionApi.WebApi.Controllers
{

    public class FamilyController : BaseController// Base2Controller<Family>
    {


        // private readonly IFamilyRepository<Family> _repo;

        /*
                public FamilyController(IFamilyRepository<Family> repo,IMediator mediatr) : base(repo,mediatr)
                {
                 //   _repo = repo;

                }
        */
        public FamilyController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Getall()
        {
             return await Handle<IEnumerable<FamilyVIewModel2>,GetAllFamilyQuery2>(new GetAllFamilyQuery2());

        }

        [HttpGet]
        [Route("ById/{id}")]
        public async Task<IActionResult> GetById([FromQuery] GetFamilyByIdQuery dto)
        {
            return await Handle<FamilyVIewModel2, GetFamilyByIdQuery>(dto);
        }


        [HttpGet]
        [Route("ByLastname")]
        public async Task<IActionResult> GetByLastname([FromQuery] GetAllFamilyByLastNameQuery dto)
        {
            return await Handle<IEnumerable<FamilyVIewModel2>, GetAllFamilyByLastNameQuery>(dto);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFamilyDTO dto)
        {
            return await Handle<CreateFamilyDTO,CreateFamilyCommand, Guid>(dto);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFamilyDTO dto)
        {
            return await Handle<UpdateFamilyDTO, UpdateFamilyCommand, int>(dto);

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteFamilyDTO dto)
        {
            return await Handle<DeleteFamilyDTO, DeleteFamilyCommand, int>(dto);

        }

    }


}
