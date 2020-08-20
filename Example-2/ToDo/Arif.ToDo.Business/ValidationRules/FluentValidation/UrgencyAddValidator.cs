using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.DTO.DTOs.UrgencyDTOs;
using FluentValidation;

namespace Arif.ToDo.Business.ValidationRules.FluentValidation
{
    public class UrgencyAddValidator : AbstractValidator<UrgencyAddDto>
    {
        public UrgencyAddValidator()
        {
            RuleFor(I => I.Description).NotNull().WithMessage("Tanım Alanı Boş Geçilemez");
        }
    }
}
