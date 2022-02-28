using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Messages.DeleteMessage
{
    public class DeleteMessageCommand:IRequest
    {
     

        public int MessageId { get; set; }

        public int UserId { get; set; }
    }
}
