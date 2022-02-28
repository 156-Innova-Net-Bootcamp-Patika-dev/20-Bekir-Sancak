using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SiteManagement.Application.Contracts.Persistence.Repositories.InvoiceTypes;
using SiteManagement.Domain.Entities.InvoiceTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.InvoiceTypes.AddInvoiceType
{
    public class AddInvoiceTypeCommandHandler : IRequestHandler<AddInvoiceTypeCommand>
    {
        private readonly IInvoiceTypeRepository _ınvoiceTypeRepository;
        private readonly IMapper _mapper;

        private readonly ILogger<AddInvoiceTypeCommandHandler> _logger;

        public AddInvoiceTypeCommandHandler(IInvoiceTypeRepository ınvoiceTypeRepository, IMapper mapper, ILogger<AddInvoiceTypeCommandHandler> logger)
        {
            this._ınvoiceTypeRepository = ınvoiceTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(AddInvoiceTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _ınvoiceTypeRepository.Get(c => c.Name.ToLower() == request.Name.ToLower());
            if (entity is not null)
                throw new Exception("Invoice Type exists in the system ");

            var invoiceType = _mapper.Map<InvoiceType>(request);

            var newInvoiceType = await _ınvoiceTypeRepository.AddAsync(invoiceType);

            _logger.LogInformation($"InvoiceType {newInvoiceType.InvoiceTypeId} is successfully created.");

            return Unit.Value;

        }
    }
}
