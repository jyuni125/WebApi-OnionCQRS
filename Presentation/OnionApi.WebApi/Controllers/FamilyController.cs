using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApi.Domain.Contracts.Repositories;
using OnionApi.Domain.Entities;
using OnionApi.WebApi.Common;

namespace OnionApi.WebApi.Controllers
{

    public class FamilyController : Base2Controller<Family>
    {
        // private readonly IFamilyRepository<Family> _repo;
     

        public FamilyController(IFamilyRepository<Family> repo,IMediator mediatr) : base(repo,mediatr)
        {
         //   _repo = repo;
      
        }
    }
    
    /*
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {


        [HttpGet]
        public async Task<IActionResult> GetMyname()
        {
            return Ok("ARBERT");
        }
    }

    */
}
