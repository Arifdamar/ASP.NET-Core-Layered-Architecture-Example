using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.DTO.DTOs.UrgencyDTOs;
using FluentValidation;

namespace Arif.ToDo.Business.ValidationRules.FluentValidation
{
    public class UrgencyUpdateValidator : AbstractValidator<UrgencyUpdateDto>
    {
        public UrgencyUpdateValidator()
        {
            RuleFor(I => I.Description).NotNull().WithMessage("Tanım Alanı Boş Geçilemez");
        }
    }
}
