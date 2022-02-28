using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Invoices.DeleteInvoice
{
    public class DeleteInvoiceValidator : AbstractValidator<DeleteInvoiceCommand>
    {
        public DeleteInvoiceValidator()
        {
            RuleFor(c => c.InvoiceId).GreaterThan(0);
            
        }
    }
}
