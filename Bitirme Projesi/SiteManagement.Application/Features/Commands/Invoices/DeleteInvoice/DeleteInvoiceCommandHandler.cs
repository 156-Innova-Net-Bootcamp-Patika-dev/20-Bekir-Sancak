using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SiteManagement.Application.Contracts.Persistence.Repositories.Invoices;
using SiteManagement.Domain.Entities.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Invoices.DeleteInvoice
{
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand>
    {
        private readonly IInvoiceRepository _ınvoiceRepository;
        private readonly IMapper _mapper;

        private readonly ILogger<DeleteInvoiceCommandHandler> _logger;

        public async Task<Unit> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoiceDelete = await _ınvoiceRepository.GetByIdAsync(request.InvoiceId);
            if(invoiceDelete ==null)
                throw new Exception("Invoice not found in the system ");

            await _ınvoiceRepository.RemoveAsync(invoiceDelete);

            _logger.LogInformation($"Invoice {invoiceDelete.InvoiceId} is successfully deleted.");

            return Unit.Value;
        }
    }
}
