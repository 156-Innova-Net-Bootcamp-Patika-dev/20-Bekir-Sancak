using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.ProcessTypes.UpdateProcessType
{
    public class UpdateProcessTypeCommand:IRequest
    {
        public int ProcessTypeId { get; set; }
        public string Name { get; set; }
    }
}
