using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.InvoiceTypes.UpdateInvoiceType
{
    public class UpdateInvoiceTypeValidator : AbstractValidator<UpdateInvoiceTypeCommand>
    {
        public UpdateInvoiceTypeValidator()
        {
            RuleFor(c => c.InvoiceTypeId).NotEmpty().GreaterThan(0);

            RuleFor(i => i.Name).NotEmpty().WithMessage("{Name} is is required.").NotNull().
           MaximumLength(20).WithMessage("{Name} must not exceed 20 characters.");
        }
    }
}
