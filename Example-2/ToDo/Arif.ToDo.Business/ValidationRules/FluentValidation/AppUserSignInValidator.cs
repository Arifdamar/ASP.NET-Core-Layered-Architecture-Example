using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.DTO.DTOs.AppUserDTOs;
using FluentValidation;

namespace Arif.ToDo.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator : AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(I => I.Password).NotNull().WithMessage("Şifre Boş Geçilemez");
        }
    }
}
