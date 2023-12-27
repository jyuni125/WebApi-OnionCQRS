using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApi.Domain.Contracts;
using OnionApi.Domain.Entities;

namespace OnionApi.WebApi.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class Base2Controller<T> : ControllerBase
        where T : class
    {
        protected readonly IFamilyRepository<T> _repo;

        public Base2Controller(IFamilyRepository<T> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(Guid id)
        {
            return Ok(await _repo.GetOne(id));
        }



        [HttpGet("{lastname}")]
        [Route("getLastName")]
        public async Task<IActionResult> GetLastName(string lastname)
        {
            return Ok(await _repo.GetLastName(lastname));
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
            await _repo.Update(t);

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
