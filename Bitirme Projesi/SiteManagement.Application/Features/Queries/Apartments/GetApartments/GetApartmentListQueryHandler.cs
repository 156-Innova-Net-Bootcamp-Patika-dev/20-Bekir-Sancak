using AutoMapper;
using MediatR;
using SiteManagement.Application.Contracts.Persistence.Repositories.Apartments;
using SiteManagement.Application.Models.Apartments;
using SiteManagement.Domain.Entities.Apartmens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Queries.Apartments.GetApartments
{
    public class GetApartmentListQueryHandler : IRequestHandler<GetApartmentListQuery, IList<ApartmentVm>>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        public GetApartmentListQueryHandler(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }

        public async Task<IList<ApartmentVm>> Handle(GetApartmentListQuery request, CancellationToken cancellationToken)
        {
            var apartments = await _apartmentRepository.GetApartmentList();

            return _mapper.Map<IList<ApartmentVm>>(apartments);
        }
    }
}
