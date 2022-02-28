using MediatR;
using SiteManagement.Application.Models.Apartments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Queries.Apartments.GetApartments
{
    public class GetApartmentListQuery:IRequest<IList<ApartmentVm>>
    {

    }
}
