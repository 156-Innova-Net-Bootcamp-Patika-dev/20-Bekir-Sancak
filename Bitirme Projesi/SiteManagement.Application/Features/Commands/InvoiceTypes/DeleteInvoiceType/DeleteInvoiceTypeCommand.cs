using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.InvoiceTypes.DeleteInvoiceType
{
    public class DeleteInvoiceTypeCommand:IRequest
    {
        public DeleteInvoiceTypeCommand(int ınvoiceTypeId)
        {
            InvoiceTypeId = ınvoiceTypeId;
        }

        public int InvoiceTypeId { get; set; }
    }
}
