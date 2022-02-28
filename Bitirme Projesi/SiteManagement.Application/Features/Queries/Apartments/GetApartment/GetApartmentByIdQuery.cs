using MediatR;
using SiteManagement.Application.Models.Apartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Queries.Apartments.GetApartment
{
    public class GetApartmentByIdQuery:IRequest<ApartmentVm>
    {
        public int ApartmentId { get; set; }
        public GetApartmentByIdQuery(int apartmentId)
        {
            ApartmentId = apartmentId;
        }

       

       
    }
}
