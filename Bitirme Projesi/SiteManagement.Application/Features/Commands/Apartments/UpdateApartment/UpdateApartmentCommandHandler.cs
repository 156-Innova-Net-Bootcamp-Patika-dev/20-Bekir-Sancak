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

namespace SiteManagement.Application.Features.Commands.Apartments.UpdateApartment
{
    public class UpdateApartmentCommandHandler : IRequestHandler<UpdateApartmentCommand>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateApartmentCommandHandler> _logger;

        public UpdateApartmentCommandHandler(IApartmentRepository apartmentRepository, IMapper mapper, ILogger<UpdateApartmentCommandHandler> logger)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateApartmentCommand request, CancellationToken cancellationToken)
        {
            var updateApartment =  await _apartmentRepository.GetByIdAsync(request.AparmentId);
           if(updateApartment is null)
                throw new Exception("Apartment not found in the system ");

            _mapper.Map(request, updateApartment, typeof(UpdateApartmentCommand), typeof(Apartment));

          await  _apartmentRepository.UpdateAsync(updateApartment);

            

          _logger.LogInformation($"Apartment {updateApartment.ApartmentId} is successfully updated.");

            return Unit.Value;
        }
    }
}
