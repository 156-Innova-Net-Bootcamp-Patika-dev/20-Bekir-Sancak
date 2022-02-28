using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Apartments.DeleteApartment
{
    public class DeleteApartmentValidator : AbstractValidator<DeleteApartmentCommand>
    {
        public DeleteApartmentValidator()
        {
            RuleFor(c => c.ApartmentId).NotEmpty().GreaterThan(0).WithMessage("{ApartmentId} is required.");
        }
    }
}
