using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Apartments.DeleteApartment
{
    public class DeleteApartmentCommand:IRequest
    {
        public int ApartmentId { get; set; }
        public DeleteApartmentCommand(int apartmentId)
        {
            ApartmentId = apartmentId;
        }

       

    }
}
