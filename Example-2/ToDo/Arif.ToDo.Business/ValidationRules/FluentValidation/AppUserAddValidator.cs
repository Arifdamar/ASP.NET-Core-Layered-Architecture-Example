using System;
using System.Collections.Generic;
using System.Text;
using Arif.ToDo.DTO.DTOs.AppUserDTOs;
using FluentValidation;

namespace Arif.ToDo.Business.ValidationRules.FluentValidation
{
    public class AppUserAddValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(I => I.UserName).NotNull().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(I => I.Password).NotNull().WithMessage("Şifre Boş Geçilemez");
            RuleFor(I => I.ConfirmPassword).NotNull().WithMessage("Şifre Onay Boş Geçilemez");
            RuleFor(I => I.ConfirmPassword).Equal(I => I.Password).WithMessage("Şifreler Eşleşmiyor");
            RuleFor(I => I.Email).NotNull().WithMessage("E-Posta Boş Geçilemez");
            RuleFor(I => I.Email).EmailAddress().WithMessage("Lütfen Geçerli Bir E-Posta Adresi Giriniz");
            RuleFor(I => I.Name).NotNull().WithMessage("İsim Boş Geçilemez");
            RuleFor(I => I.SurName).NotNull().WithMessage("Soy İsim Boş Geçilemez");
        }
    }
}
