using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Messages.AddMessage
{
    public class AddMessageCommand:IRequest
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public int? SenderId { get; set; }

        public int? RenderId { get; set; }

    }
}
