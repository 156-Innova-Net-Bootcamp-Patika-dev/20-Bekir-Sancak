using MediatR;
using SiteManagement.Application.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Queries.Messages.GetMessages
{
    public class GetMessageListQuery:IRequest<IList<MessageVm>>
    {
        public int UserId { get; set; }
       

        
    }
}
