using MediatR;
using SiteManagement.Application.Models.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Queries.Invoices.GetInvoice
{
    public class GetInvoiceByIdQuery:IRequest<IList<InvoiceVm>>
    {
        public GetInvoiceByIdQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}
