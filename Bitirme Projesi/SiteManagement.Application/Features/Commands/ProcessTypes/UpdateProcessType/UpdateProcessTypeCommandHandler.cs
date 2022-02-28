using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SiteManagement.Application.Contracts.Persistence.Repositories.ProcessTypes;
using SiteManagement.Domain.Entities.ProcessTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.ProcessTypes.UpdateProcessType
{
    public class UpdateProcessTypeCommandHandler : IRequestHandler<UpdateProcessTypeCommand>
    {
        private readonly IProcessTypeRepository _processTypeRepository;

        private readonly IMapper _mapper;

        private readonly ILogger<UpdateProcessTypeCommandHandler> _logger;

        public UpdateProcessTypeCommandHandler(IProcessTypeRepository processTypeRepository, IMapper mapper, ILogger<UpdateProcessTypeCommandHandler> logger)
        {
            _processTypeRepository = processTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateProcessTypeCommand request, CancellationToken cancellationToken)
        {
            var updateProcessType = await _processTypeRepository.GetByIdAsync(request.ProcessTypeId);
            if (updateProcessType is null)
                throw new Exception("PpocessType not found in the system ");

            _mapper.Map(request, updateProcessType, typeof(UpdateProcessTypeCommand), typeof(ProcessType));

            await _processTypeRepository.UpdateAsync(updateProcessType);

            _logger.LogInformation($"InvoiceType {updateProcessType.ProcessTypeId} is successfully updated.");

            return Unit.Value;
        }
    }
}
