using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Invoices.AddInvoice
{
    public class AddInvoiceCommand:IRequest
    {
        

        public int ApartmentId { get; set; }

        public int Month { get; set; }

        public double Price { get; set; }

        public int ProcessTypeId { get; set; }

        public int InvoiceTypeId { get; set; }

       
    }
}
