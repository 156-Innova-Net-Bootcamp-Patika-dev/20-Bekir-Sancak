using MediatR;
using SiteManagement.Application.Models.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Queries.Invoices.GetInvoices
{
    public class GetInvoiceListQuery:IRequest<IList<InvoiceVm>>
    {

    }
}
