using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Apartments.AddApartment
{
    public class AddApartmentCommand:IRequest
    {

        public char    Block { get; set; }
        public string ApartmentType { get; set; }
        public int Floor { get; set; }
        public int No { get; set; }
        public int OwnerId { get; set; }

        public int UserId { get; set; }
    }
}
