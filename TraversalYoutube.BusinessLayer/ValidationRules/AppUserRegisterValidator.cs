using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.DTOLayer.DTOs.AppUserDTOs;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.ValidationRules;
public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
{
    public AppUserRegisterValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
        RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez");
        RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez");
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası alanı boş geçilemez");
        RuleFor(x => x.PhoneNumber).MaximumLength(11).WithMessage("Telefon numarası en fazla 11 karakter olmalıdır");
        RuleFor(x => x.PhoneNumber).MinimumLength(10).WithMessage("Telefon numarası en az 10 karakter olmalıdır");
        RuleFor(x => x.PhoneNumber).Matches("[0-9]").WithMessage("Telefon numarası tamamen sayılardan oluşmalıdır");
        RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı alanı boş geçilemez")
                                .Matches(@"^[^\u00c0-\u017F]+$").WithMessage("Kullanıcı Adı Türkçe karakter içermemelidir");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
        RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre Yineleme alanı boş geçilemez");
        RuleFor(x => x.Username).MaximumLength(20).WithMessage("Lütfen en fazla 20 karatker girişi yapın");
        RuleFor(x => x.Username).MinimumLength(5).WithMessage("Lütfen en az 5 karatker girişi yapın");

        RuleFor(x => x.Password)
                    .NotEmpty().WithMessage("Şifre alanı boş geçilemez")
                    .Matches("[A-Z]").WithMessage("Şifre en az 1 büyük harf içermelidir")
                    .Matches("[a-z]").WithMessage("Şifre en az 1 küçük harf içermelidir")
                    .Matches("[0-9]").WithMessage("Şifre rakam içermelidir")
                    .Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az 1 özel karakter içermelidir");

        RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Şifreler birbiriyle uyuşmuyor");

       
    }
}
