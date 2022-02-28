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

namespace SiteManagement.Application.Features.Commands.Owners.DeleteOwner
{
    public class DeleteOwnerCommandHandler : IRequestHandler<DeleteOwnerCommand>
    {
        private readonly IOwnerRepository _ownerRepository;

        private readonly IMapper _mapper;

        private readonly ILogger<DeleteOwnerCommandHandler> _logger;


        public async Task<Unit> Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
        {
            var deleteOwner = await _ownerRepository.GetByIdAsync(request.OwnerId);
            if (deleteOwner == null)
                throw new Exception("Owner not found in the system ");

            await _ownerRepository.RemoveAsync(deleteOwner);

            _logger.LogInformation($"Owner {deleteOwner.OwnerId} is successfully deleted.");

            return Unit.Value;
        }
    }
}
