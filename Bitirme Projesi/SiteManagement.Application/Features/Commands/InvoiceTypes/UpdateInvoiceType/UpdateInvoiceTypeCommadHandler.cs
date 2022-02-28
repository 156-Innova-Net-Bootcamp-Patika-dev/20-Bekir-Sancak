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

namespace SiteManagement.Application.Features.Commands.InvoiceTypes.UpdateInvoiceType
{
    public class UpdateInvoiceTypeCommadHandler : IRequestHandler<UpdateInvoiceTypeCommand>
    {

        private readonly IInvoiceTypeRepository _ınvoiceTypeRepository;
        private readonly IMapper _mapper;

        private readonly ILogger<UpdateInvoiceTypeCommadHandler> _logger;

        public UpdateInvoiceTypeCommadHandler(IInvoiceTypeRepository ınvoiceTypeRepository, IMapper mapper, ILogger<UpdateInvoiceTypeCommadHandler> logger)
        {
            _ınvoiceTypeRepository = ınvoiceTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateInvoiceTypeCommand request, CancellationToken cancellationToken)
        {
            var updateInvoiceType = await _ınvoiceTypeRepository.GetByIdAsync(request.InvoiceTypeId);
            if(updateInvoiceType is null)

                throw new Exception("Invoice Type not found in the system ");
            _mapper.Map(request, updateInvoiceType, typeof(UpdateInvoiceTypeCommand), typeof(InvoiceType));
            
            await  _ınvoiceTypeRepository.UpdateAsync(updateInvoiceType);

            _logger.LogInformation($"InvoiceType {updateInvoiceType.InvoiceTypeId} is successfully updated.");

            return Unit.Value;

        }
    }
}
