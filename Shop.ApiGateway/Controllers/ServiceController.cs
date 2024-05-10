using ApiGateway.Application.Commands.CreateService;
using ApiGateway.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shop.ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<ResponseDto<bool>>> CreateService([FromBody] CreateServiceCommand createServiceCommand)
        {
            var result = await _mediator.Send(createServiceCommand);

            return Ok(result);
        }
    }
}
