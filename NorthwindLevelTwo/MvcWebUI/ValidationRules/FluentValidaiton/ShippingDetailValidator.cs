using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MvcWebUI.Models;

namespace MvcWebUI.ValidationRules.FluentValidaiton
{
    public class ShippingDetailValidator : AbstractValidator<ShippingDetail>
    {
        public ShippingDetailValidator()
        {
            RuleFor(sd => sd.FirstName).NotEmpty().WithMessage("First Name is Required!");
            RuleFor(sd => sd.FirstName).MinimumLength(3);
            RuleFor(sd => sd.LastName).NotEmpty().WithMessage("Last Name is Required!");
            RuleFor(sd => sd.Address).NotEmpty();
            RuleFor(sd => sd.Email).EmailAddress();

            RuleFor(sd => sd.City).NotEmpty().When(sd => sd.Age < 18);

            //RuleFor(sd => sd.FirstName).Must(StartsWithA);
        }

        private bool StartsWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
