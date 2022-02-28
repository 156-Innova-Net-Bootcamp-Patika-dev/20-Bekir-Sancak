using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Invoices.AddInvoice
{
    public class AddInvoiceValidator : AbstractValidator<AddInvoiceCommand>
    {
        public AddInvoiceValidator()
        {
            RuleFor(c => c.ApartmentId).GreaterThan(0);
            RuleFor(c => c.Month).GreaterThan(0);
            RuleFor(c => c.ProcessTypeId).GreaterThan(0);
            RuleFor(c => c.InvoiceTypeId).GreaterThan(0);
            RuleFor(c => c.Price).GreaterThan(0);
        }
    }
}
