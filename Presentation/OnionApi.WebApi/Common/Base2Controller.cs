using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApi.Core.Queries.Family;
using OnionApi.Domain.Contracts.Repositories;
using OnionApi.Domain.Entities;
using OnionApi.Application.Queries.Family;

namespace OnionApi.WebApi.Common
{
    [Route("api/[controller]/")]
    [ApiController]
    public class Base2Controller<T> : ControllerBase
     
    {
        protected readonly IFamilyRepository<T> _repo;
        private readonly IMediator _mediatr;
        public Base2Controller(IFamilyRepository<T> repo,IMediator mediatr)
        {
            _repo = repo;
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
             //return Ok(await _repo.GetAll());

            var myresponse =await _mediatr.Send(new GetAllFamilyQuery2());

            return Ok(myresponse);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(Guid id)
        {
            return Ok(await _repo.GetOne(id));
        }



        [HttpGet("getLastName/{lastname}")]
        //[Route("getLastName")]
        public async Task<IActionResult> GetLastName(string lastname)
        {
            return Ok();//await _repo.GetLastName(lastname));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] T t)
        {
           await _repo.Create(t);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] T t)
        {
           // await _repo.Update(t);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            await _repo.Delete(id);

            return Ok();
        }
    }
}
