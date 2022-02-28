using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Application.Features.Commands.Owners.AddOwner;
using SiteManagement.Application.Features.Commands.Owners.DeleteOwner;
using SiteManagement.Application.Features.Commands.Owners.UpdateOwner;
using System.Threading.Tasks;

namespace SiteManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class OwnersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OwnersController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost("AddOwner")]
        public async Task<IActionResult> AddOwner([FromBody] AddOwnerCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpPut("UpdateOwner")]
        public async Task<IActionResult> UpdateOwner([FromBody] UpdateOwnerCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpDelete("DeleteOwner")]
        public async Task<IActionResult> DeleteOwner(int ownerId)
        {
            var query = new DeleteOwnerCommand(ownerId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
