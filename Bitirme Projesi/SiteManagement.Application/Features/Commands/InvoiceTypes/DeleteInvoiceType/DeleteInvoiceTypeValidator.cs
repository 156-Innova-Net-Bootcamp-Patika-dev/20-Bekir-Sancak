using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.InvoiceTypes.DeleteInvoiceType
{
    public class DeleteInvoiceTypeValidator : AbstractValidator<DeleteInvoiceTypeCommand>
    {
        public DeleteInvoiceTypeValidator()
        {
            RuleFor(c => c.InvoiceTypeId).NotEmpty().GreaterThan(0);
        }
    }
}
