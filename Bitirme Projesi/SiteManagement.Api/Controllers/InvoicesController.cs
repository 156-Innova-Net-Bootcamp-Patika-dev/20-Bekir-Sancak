using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Application.Features.Commands.Invoices.AddInvoice;
using SiteManagement.Application.Features.Commands.Invoices.DeleteInvoice;
using SiteManagement.Application.Features.Commands.Invoices.UpdateInvoice;
using SiteManagement.Application.Features.Queries.Invoices.GetInvoice;
using SiteManagement.Application.Features.Queries.Invoices.GetInvoices;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SiteManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetInvoices")]
        public async Task<IActionResult> GetInvoices()
        {
            return Ok(await _mediator.Send(new GetInvoiceListQuery()));
        }

        [HttpGet("GetInvoiceById")]
        public async Task<IActionResult> GetInvoiceById([FromQuery] GetInvoiceByIdQuery query)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            query.UserId = userId;
            return Ok(await _mediator.Send(query));
        }


        [HttpPost("AddInvoice")]
        public async Task<IActionResult> AddInvoice([FromBody] AddInvoiceCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpPut("UpdateInvoice")]
        public async Task<IActionResult> UpdateInvoice([FromBody] UpdateInvoiceCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpDelete("DeleteInvoice")]
        public async Task<IActionResult> DeleteInvoice(int invoiceId)
        {
            var query = new DeleteInvoiceCommand(invoiceId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }




    }
}
