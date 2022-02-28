using AutoMapper;
using MediatR;
using SiteManagement.Application.Contracts.Persistence.Repositories.Apartments;
using SiteManagement.Application.Models.Apartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Queries.Apartments.GetApartment
{
    public class GetApartmentByIdQueryHandler : IRequestHandler<GetApartmentByIdQuery, ApartmentVm>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        public GetApartmentByIdQueryHandler(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }
        public async Task<ApartmentVm> Handle(GetApartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var aparment = await _apartmentRepository.GetApartmentById(request.ApartmentId);

            return _mapper.Map<ApartmentVm>(aparment);
        }
    }
}
