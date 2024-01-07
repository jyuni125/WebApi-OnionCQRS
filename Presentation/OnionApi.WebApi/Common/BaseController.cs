using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionApi.Application.Commands.Family;
using OnionApi.Application.Commons;
using OnionApi.Application.DTOs.Family;
using OnionApi.Application.Queries.Family;
using OnionApi.Application.ViewModel;

namespace OnionApi.WebApi.Common
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IMapper _mapper;
        protected readonly IMediator _mediator;

        public BaseController(IMediator mediator,IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        protected async Task<IActionResult> Handle<T1, T2, T3>(T1 dto)
        {

            var queryOrCommmand = _mapper.Map<T2>(dto);

            return await Handle<T3,T2>(queryOrCommmand);
            
        }

       


        protected async Task<IActionResult> Handle<T1,T2>(T2 queryOrCommmand)
         
        {
            
            if (queryOrCommmand == null)
                return BadRequest();

            var result = new QueryOrCommandResult<T1>();
            if (ModelState.IsValid)
            {
                try
                {
                    var returndata = await _mediator.Send(queryOrCommmand);
                    result.Data = (T1?)returndata;
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Messages.Add(ex.Message);
                }
            }
            else
            {
                result.Messages = ModelState.Values.SelectMany(m => m.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
            }

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);

        }





    }
}
