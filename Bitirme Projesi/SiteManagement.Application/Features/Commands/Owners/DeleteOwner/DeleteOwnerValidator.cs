using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Owners.DeleteOwner
{
    public class DeleteOwnerValidator : AbstractValidator<DeleteOwnerCommand>
    {
        public DeleteOwnerValidator()
        {
            RuleFor(c => c.OwnerId).NotEmpty().GreaterThan(0);
        }
    }
}
