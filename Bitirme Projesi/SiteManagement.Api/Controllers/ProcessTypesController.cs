using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Application.Features.Commands.ProcessTypes.AddProcessType;
using SiteManagement.Application.Features.Commands.ProcessTypes.DeleteProcessType;
using SiteManagement.Application.Features.Commands.ProcessTypes.UpdateProcessType;
using System.Threading.Tasks;

namespace SiteManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class ProcessTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProcessTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddProcessType")]
        public async Task<IActionResult> AddProcessType([FromBody] AddProcessTypeCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpPut("UpdateProcessType")]
        public async Task<IActionResult> UpdateProcessType([FromBody] UpdateProcessTypeCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpDelete("DeleteProcessType")]
        public async Task<IActionResult> DeleteProcessType(int processTypeId)
        {
            var query = new DeleteProcessTypeCommand(processTypeId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
