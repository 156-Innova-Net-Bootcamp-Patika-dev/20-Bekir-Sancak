using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Application.Features.Commands.Apartments.AddApartment
{
    public class AddApartmentValidator : AbstractValidator<AddApartmentCommand>
    {
        public AddApartmentValidator()
        {
            RuleFor(c=> c.OwnerId).NotEmpty().GreaterThan(0).WithMessage("{OwnerId} is required.");

            RuleFor(c => c.UserId).NotEmpty().GreaterThan(0).WithMessage("{UserId} is required.");

            RuleFor(p => p.Block)
            .NotEmpty().WithMessage("{Block} is required.").NotNull();


            RuleFor(p => p.ApartmentType)
           .NotEmpty().WithMessage("{Block} is required.").NotNull();
          

            RuleFor(c => c.Floor).NotEmpty().GreaterThan(0).WithMessage("{Floor} is required.");

            RuleFor(c => c.No).NotEmpty().GreaterThan(0).WithMessage("{No} is required.");


        }
    }
}
