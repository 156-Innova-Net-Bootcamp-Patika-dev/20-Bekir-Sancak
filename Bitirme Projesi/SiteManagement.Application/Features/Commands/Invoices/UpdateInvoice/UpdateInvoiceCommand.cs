using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Invoices.UpdateInvoice
{
    public class UpdateInvoiceCommand:IRequest
    {
        public int InvoiceId { get; set; }
        public int ApartmentId { get; set; }

        public int Month { get; set; }

        public float Price { get; set; }

        public int ProcessTypeId { get; set; }

        public int InvoiceTypeId { get; set; }
    }
}
