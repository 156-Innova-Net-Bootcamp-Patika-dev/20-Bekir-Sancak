using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteManagement.Application.Features.Commands.InvoiceTypes.AddInvoiceType;
using SiteManagement.Application.Features.Commands.InvoiceTypes.DeleteInvoiceType;
using SiteManagement.Application.Features.Commands.InvoiceTypes.UpdateInvoiceType;
using System.Threading.Tasks;

namespace SiteManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvoiceTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InvoiceTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("AddInvoiceType")]
        public async Task<IActionResult> AddInvoiceType([FromBody] AddInvoiceTypeCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpPut("UpdateInvoiceType")]
        public async Task<IActionResult> UpdateInvoiceType([FromBody] UpdateInvoiceTypeCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteInvoiceType(int invoiceTypeId)
        {
            var query = new DeleteInvoiceTypeCommand(invoiceTypeId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}

