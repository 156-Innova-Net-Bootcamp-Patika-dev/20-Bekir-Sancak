using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.InvoiceTypes.UpdateInvoiceType
{
    public class UpdateInvoiceTypeCommand:IRequest
    {
        public int InvoiceTypeId { get; set; }
        public string Name { get; set; }

    
    }
}
