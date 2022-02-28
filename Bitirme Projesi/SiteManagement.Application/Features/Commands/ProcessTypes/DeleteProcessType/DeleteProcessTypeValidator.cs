using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.ProcessTypes.DeleteProcessType
{
    public class DeleteProcessTypeValidator : AbstractValidator<DeleteProcessTypeCommand>
    {
        public DeleteProcessTypeValidator()
        {

            RuleFor(c => c.ProcessTypeId).NotEmpty().GreaterThan(0);
        }
    }
}
