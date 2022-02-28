using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.ProcessTypes.AddProcessType
{
    public class AddProcessTypeCommand:IRequest
    {

        public string Name { get; set; }
    }
}
