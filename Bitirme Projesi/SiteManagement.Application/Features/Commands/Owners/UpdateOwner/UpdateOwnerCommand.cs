using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Owners.UpdateOwner
{
    public class UpdateOwnerCommand:IRequest
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
    }
}
