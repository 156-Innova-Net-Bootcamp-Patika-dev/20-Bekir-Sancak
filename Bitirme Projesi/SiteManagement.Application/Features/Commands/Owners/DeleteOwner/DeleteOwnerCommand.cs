using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Owners.DeleteOwner
{
    public class DeleteOwnerCommand:IRequest
    {
        public int OwnerId { get; set; }
        public DeleteOwnerCommand(int ownerId)
        {
            OwnerId = ownerId;
        }

       
    }
}
