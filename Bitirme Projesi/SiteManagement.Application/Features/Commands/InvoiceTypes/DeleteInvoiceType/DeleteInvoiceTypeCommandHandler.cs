using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SiteManagement.Application.Contracts.Persistence.Repositories.Apartments;
using SiteManagement.Application.Contracts.Persistence.Repositories.InvoiceTypes;
using SiteManagement.Domain.Entities.InvoiceTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.InvoiceTypes.DeleteInvoiceType
{
    public class DeleteInvoiceTypeCommandHandler : IRequestHandler<DeleteInvoiceTypeCommand>
    {
        private readonly IInvoiceTypeRepository _ınvoiceTypeRepository;
        private readonly IMapper _mapper;

        private readonly ILogger<DeleteInvoiceTypeCommandHandler> _logger;


        public DeleteInvoiceTypeCommandHandler(IInvoiceTypeRepository ınvoiceTypeRepository, IMapper mapper, ILogger<DeleteInvoiceTypeCommandHandler> logger)
        {
            _ınvoiceTypeRepository = ınvoiceTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteInvoiceTypeCommand request, CancellationToken cancellationToken)
        {
            var deleteInvoiceType = await _ınvoiceTypeRepository.GetByIdAsync(request.InvoiceTypeId);
            if(deleteInvoiceType == null)
                throw new Exception("Invoice Type not found in the system ");

            await _ınvoiceTypeRepository.RemoveAsync(deleteInvoiceType);

            _logger.LogInformation($"InvoiceType {deleteInvoiceType.InvoiceTypeId} is successfully deleted.");

            return Unit.Value;

        }
    }
}
