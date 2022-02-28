using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SiteManagement.Application.Contracts.Persistence.Repositories.Invoices;
using SiteManagement.Application.Features.Commands.Invoices.DeleteInvoice;
using SiteManagement.Domain.Entities.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Invoices.UpdateInvoice
{
    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand>
    {
        private readonly IInvoiceRepository _ınvoiceRepository;
        private readonly IMapper _mapper;

        private readonly ILogger<DeleteInvoiceCommandHandler> _logger;
        public async Task<Unit> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var updateInvoice = await _ınvoiceRepository.GetByIdAsync(request.InvoiceId);
            if (updateInvoice is null)
                throw new Exception("Invoice not found in the system ");

            _mapper.Map(request, updateInvoice, typeof(UpdateInvoiceCommand), typeof(Invoice));

            await _ınvoiceRepository.UpdateAsync(updateInvoice);

            _logger.LogInformation($"InvoiceType {updateInvoice.InvoiceId} is successfully updated.");

            return Unit.Value;
        }
    }
}
