using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SiteManagement.Application.Contracts.Persistence.Repositories.Owners;
using SiteManagement.Domain.Entities.Owners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Owners.AddOwner
{
    public class AddOwnerCommandHandler : IRequestHandler<AddOwnerCommand>
    {

        private readonly IOwnerRepository _ownerRepository;

        private readonly IMapper _mapper;

        private readonly ILogger<AddOwnerCommandHandler> _logger;

        public AddOwnerCommandHandler(IOwnerRepository ownerRepository, IMapper mapper, ILogger<AddOwnerCommandHandler> logger)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(AddOwnerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _ownerRepository.Get(c => c.Name.ToLower() == request.Name.ToLower());
            if (entity is not null)
                throw new Exception("Owners exists in the system");

            var owner = _mapper.Map<Owner>(request);

            var newOwner = await _ownerRepository.AddAsync(owner);

            _logger.LogInformation($"ProcessType {newOwner.OwnerId} is successfully created.");

            return Unit.Value;
        }
    }
}
