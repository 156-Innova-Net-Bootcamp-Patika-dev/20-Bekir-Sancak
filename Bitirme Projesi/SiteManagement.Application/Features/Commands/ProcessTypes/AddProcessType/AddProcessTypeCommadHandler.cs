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

namespace SiteManagement.Application.Features.Commands.ProcessTypes.AddProcessType
{
    public class AddProcessTypeCommadHandler : IRequestHandler<AddProcessTypeCommand>
    {
        private readonly IProcessTypeRepository _processTypeRepository;

        private readonly IMapper _mapper;

        private readonly ILogger<AddProcessTypeCommadHandler> _logger;

        public AddProcessTypeCommadHandler(IProcessTypeRepository processTypeRepository, IMapper mapper, ILogger<AddProcessTypeCommadHandler> logger)
        {
            _processTypeRepository = processTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(AddProcessTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _processTypeRepository.Get(c => c.Name.ToLower() == request.Name.ToLower());
            if (entity is not null)
                throw new Exception("ProcessType exists in the system");

            var processType = _mapper.Map<ProcessType>(request);

            var newProcessType = await _processTypeRepository.AddAsync(processType);

            _logger.LogInformation($"ProcessType {newProcessType.ProcessTypeId} is successfully created.");

            return Unit.Value;
        }
    }
}
