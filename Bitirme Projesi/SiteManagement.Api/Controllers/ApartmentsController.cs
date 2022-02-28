using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Application.Features.Commands.Apartments.AddApartment;
using SiteManagement.Application.Features.Commands.Apartments.DeleteApartment;
using SiteManagement.Application.Features.Commands.Apartments.UpdateApartment;
using SiteManagement.Application.Features.Queries.Apartments.GetApartment;
using SiteManagement.Application.Features.Queries.Apartments.GetApartments;
using System.Threading.Tasks;

namespace SiteManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = "Admin")]

    public class ApartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetApartments")]
        public async Task<IActionResult> GetApartments()
        {
            return Ok(await _mediator.Send(new GetApartmentListQuery()));
        }

        [HttpGet("GetApartmentById")]
        public async Task<IActionResult> GetApartmentById([FromQuery] int apartmentId)
        {
            var query = new GetApartmentByIdQuery(apartmentId);
            return Ok(await _mediator.Send(query));
        }

        [HttpPost("AddApartment")]
        public async Task<IActionResult> AddApartment([FromBody] AddApartmentCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("UpdateApartment")]
        public async Task<IActionResult> UpdateApartment([FromBody] UpdateApartmentCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("DeleteApartment")]
        public async Task<IActionResult> DeleteApartment(int apartmentId)
        {
            var query = new DeleteApartmentCommand(apartmentId);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

    }
}
