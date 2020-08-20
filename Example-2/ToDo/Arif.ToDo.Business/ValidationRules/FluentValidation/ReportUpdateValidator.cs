using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.DTO.DTOs.ReportDTOs;
using FluentValidation;

namespace Arif.ToDo.Business.ValidationRules.FluentValidation
{
    public class ReportUpdateValidator : AbstractValidator<ReportUpdateDto>
    {
        public ReportUpdateValidator()
        {
            RuleFor(I => I.Definition).NotNull().WithMessage("Tanım Alanı Boş Geçilemez");
            RuleFor(I => I.Description).NotNull().WithMessage("Açıklama Alanı Boş Geçilemez");
        }
    }
}
