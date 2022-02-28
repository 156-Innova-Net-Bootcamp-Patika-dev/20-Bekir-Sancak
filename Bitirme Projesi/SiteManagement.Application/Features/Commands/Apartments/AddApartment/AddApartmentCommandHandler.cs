using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SiteManagement.Application.Contracts.Persistence.Repositories.Apartments;
using SiteManagement.Domain.Entities.Apartmens;
using SiteManagement.Domain.Enum.Apartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Apartments.AddApartment
{
    public class AddApartmentCommandHandler : IRequestHandler<AddApartmentCommand>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        private readonly ILogger<AddApartmentCommandHandler> _logger;

        public AddApartmentCommandHandler(IApartmentRepository apartmentRepository, IMapper mapper, ILogger<AddApartmentCommandHandler> logger)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(AddApartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _apartmentRepository.Get(c=> c.Block==request.Block && c.No == request.No && c.Floor==c.Floor);
            if (entity is not null)
                throw new Exception("Apartment exists in the system ");
             

            var apartment = _mapper.Map<Apartment>(request);

            apartment.Status = (int)ApartmentStatusEnum.Fullhouse;

           var newApartment=  await  _apartmentRepository.AddAsync(apartment);

          _logger.LogInformation($"Apartment {newApartment.ApartmentId} is successfully created.");

          return Unit.Value;
        }
    }
}
