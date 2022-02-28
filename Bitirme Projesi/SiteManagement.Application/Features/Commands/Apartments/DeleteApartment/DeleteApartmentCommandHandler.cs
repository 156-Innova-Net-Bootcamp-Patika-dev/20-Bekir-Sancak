using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SiteManagement.Application.Contracts.Persistence.Repositories.Apartments;

using SiteManagement.Domain.Entities.Apartmens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Apartments.DeleteApartment
{
    internal class DeleteApartmentCommandHandler : IRequestHandler<DeleteApartmentCommand>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteApartmentCommandHandler> _logger;

        public DeleteApartmentCommandHandler(IApartmentRepository apartmentRepository, IMapper mapper, ILogger<DeleteApartmentCommandHandler> logger)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteApartmentCommand request, CancellationToken cancellationToken)
        {
            var apartmentDelete = await _apartmentRepository.GetByIdAsync(request.ApartmentId);
            if (apartmentDelete == null)
                throw new Exception("Apartment not found in the system ");

            await  _apartmentRepository.RemoveAsync(apartmentDelete);

          _logger.LogInformation($"Apartment {apartmentDelete.ApartmentId} is successfully deleted.");

          return Unit.Value;
        }
    }
}
