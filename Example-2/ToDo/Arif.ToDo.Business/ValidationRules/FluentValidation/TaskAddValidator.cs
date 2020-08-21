using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.DTO.DTOs.TaskDTOs;
using FluentValidation;

namespace Arif.ToDo.Business.ValidationRules.FluentValidation
{
    public class TaskAddValidator : AbstractValidator<TaskAddDto>
    {
        public TaskAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Görevin Adı Boş Geçilemez");
            RuleFor(I => I.UrgencyId).ExclusiveBetween(0, int.MaxValue).WithMessage("Lütfen Geçerli Bir Aciliyet Durumu Seçiniz");
        }
    }
}
