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

namespace SiteManagement.Application.Features.Commands.ProcessTypes.DeleteProcessType
{
    public class DeleteProcessTypeCommandHandler:IRequestHandler<DeleteProcessTypeCommand>
    {
        private readonly IProcessTypeRepository _processTypeRepository;

        private readonly IMapper _mapper;

        private readonly ILogger<DeleteProcessTypeCommandHandler> _logger;

        public DeleteProcessTypeCommandHandler(IProcessTypeRepository processTypeRepository, IMapper mapper, ILogger<DeleteProcessTypeCommandHandler> logger)
        {
            _processTypeRepository = processTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async  Task<Unit> Handle(DeleteProcessTypeCommand request, CancellationToken cancellationToken)
        {
            var deleteProcessType = await _processTypeRepository.GetByIdAsync(request.ProcessTypeId);
            if (deleteProcessType == null)
                throw new Exception("ProcessType not found in the system ");
            await _processTypeRepository.RemoveAsync(deleteProcessType);

            _logger.LogInformation($"ProcessType {deleteProcessType.ProcessTypeId} is successfully deleted.");

            return Unit.Value;
        }
    }
}
