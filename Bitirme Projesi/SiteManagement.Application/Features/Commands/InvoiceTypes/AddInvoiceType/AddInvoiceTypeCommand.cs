using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.InvoiceTypes.AddInvoiceType
{
    public class AddInvoiceTypeCommand:IRequest
    {
       
        public string Name { get; set; }
    }
}
