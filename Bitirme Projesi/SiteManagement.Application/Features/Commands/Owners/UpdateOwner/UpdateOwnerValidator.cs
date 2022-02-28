using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Owners.UpdateOwner
{
    public class UpdateOwnerValidator : AbstractValidator<UpdateOwnerCommand>
    {
        public UpdateOwnerValidator()
        {
            RuleFor(c => c.OwnerId).NotEmpty().GreaterThan(0);
            RuleFor(i => i.Name).NotEmpty().WithMessage("{Name} is is required.").NotNull().
         MaximumLength(10).WithMessage("{Name} must not exceed 10 characters.");
        }
    }
}
