using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Application.Features.Commands.Messages.AddMessage;
using SiteManagement.Application.Features.Commands.Messages.DeleteMessage;
using SiteManagement.Application.Features.Commands.Messages.UpdateMessage;
using SiteManagement.Application.Features.Queries.Messages.GetMessages;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SiteManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MessagesController(IMediator mediator)
        {
            mediator = _mediator;
        }
        [HttpGet("GetMessages")]
        public async Task<IActionResult> GetMessages(GetMessageListQuery query)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            query.UserId = userId;
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("AddMessage")]
        public async Task<IActionResult> AddMessage([FromBody] AddMessageCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);

        }

        [HttpPut("UpdateMessage")]
        public async Task<IActionResult> UpdateMessage([FromBody] UpdateMessageCommand command)
        {

            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            command.UserId = userId;
            var result = await _mediator.Send(command);
            return Ok(result);

        }

        [HttpDelete("DeleteMessage")]
        public async Task<IActionResult> DeleteMessage(DeleteMessageCommand command)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            command.UserId = userId;

            var result = await _mediator.Send(command);
            return Ok(result);

        }

    }

}
