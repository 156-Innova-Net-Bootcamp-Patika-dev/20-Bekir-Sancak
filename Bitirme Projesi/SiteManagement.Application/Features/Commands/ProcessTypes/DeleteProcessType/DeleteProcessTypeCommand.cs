using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.ProcessTypes.DeleteProcessType
{
    public class DeleteProcessTypeCommand:IRequest
    {
        public DeleteProcessTypeCommand(int processTypeId)
        {
            ProcessTypeId = processTypeId;
        }

        public int ProcessTypeId { get; set; }
    }
}
