using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.ProcessTypes.UpdateProcessType
{
    public class UpdateProcessTypeValidator : AbstractValidator<UpdateProcessTypeCommand>
    {
        public UpdateProcessTypeValidator()
        {

            RuleFor(c => c.ProcessTypeId).NotEmpty().GreaterThan(0);

            RuleFor(i => i.Name).NotEmpty().WithMessage("{Name} is is required.").NotNull().
          MaximumLength(10).WithMessage("{Name} must not exceed 10 characters.");
        }
    }
}
