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

namespace SiteManagement.Application.Features.Commands.Invoices.AddInvoice
{
    public class AddInvoiceCommandHandler : IRequestHandler<AddInvoiceCommand>
    {
        private readonly IInvoiceRepository _ınvoiceRepository;
        private readonly IMapper _mapper;

        private readonly ILogger<AddInvoiceCommandHandler> _logger;

        public AddInvoiceCommandHandler(IInvoiceRepository ınvoiceRepository, IMapper mapper, ILogger<AddInvoiceCommandHandler> logger)
        {
            _ınvoiceRepository = ınvoiceRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(AddInvoiceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _ınvoiceRepository.Get(c => c.ApartmentId == request.ApartmentId && c.InvoiceTypeId == request.InvoiceTypeId && c.ProcessTypeId == request.ProcessTypeId && c.Month == request.Month);
            if (entity is not null)
                throw new Exception("Invoice exists in the system ");
            var invoice = _mapper.Map<Invoice>(request);
                invoice.IsPaid = false;

                var newInvoice = await _ınvoiceRepository.AddAsync(invoice);

            _logger.LogInformation($"Invoice {newInvoice.InvoiceId} is successfully created.");

            return Unit.Value;
        }
    }
}
