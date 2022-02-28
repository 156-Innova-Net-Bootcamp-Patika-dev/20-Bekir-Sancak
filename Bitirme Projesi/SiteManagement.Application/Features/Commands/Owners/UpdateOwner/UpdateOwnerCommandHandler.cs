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

namespace SiteManagement.Application.Features.Commands.Owners.UpdateOwner
{
    public class UpdateOwnerCommandHandler : IRequestHandler<UpdateOwnerCommand>
    {
        private readonly IOwnerRepository _ownerRepository;

        private readonly IMapper _mapper;

        private readonly ILogger<UpdateOwnerCommand> _logger;

        public UpdateOwnerCommandHandler(IOwnerRepository ownerRepository, IMapper mapper, ILogger<UpdateOwnerCommand> logger)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
        {
            var updateOwner = await _ownerRepository.GetByIdAsync(request.OwnerId);
            if (updateOwner is null)
                throw new Exception("Owner not found in the system ");

            _mapper.Map(request, updateOwner, typeof(UpdateOwnerCommand), typeof(Owner));

            await _ownerRepository.UpdateAsync(updateOwner);

            _logger.LogInformation($"InvoiceType {updateOwner.OwnerId} is successfully updated.");

            return Unit.Value;
        }
    }
}
