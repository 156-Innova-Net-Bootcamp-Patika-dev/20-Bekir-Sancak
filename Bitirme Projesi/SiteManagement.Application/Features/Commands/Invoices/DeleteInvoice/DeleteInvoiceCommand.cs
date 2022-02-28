using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Invoices.DeleteInvoice
{
    public class DeleteInvoiceCommand:IRequest
    {
        public int InvoiceId { get; set; }
        public DeleteInvoiceCommand(int ınvoiceId)
        {
            InvoiceId = ınvoiceId;
        }

       
    }
}
