using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Owners.AddOwner
{
    public class AddOwnerCommand:IRequest
    {
        public string Name { get; set; }
    }
}
