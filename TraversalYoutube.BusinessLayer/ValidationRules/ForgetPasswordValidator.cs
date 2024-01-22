using FluentValidation;
using TraversalYoutube.DTOLayer.DTOs.AppUserDTOs;

namespace TraversalYoutube.BusinessLayer.ValidationRules;
public class ForgetPasswordValidator : AbstractValidator<ResetPasswordDTO>
{
    public ForgetPasswordValidator()
    {
        RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifreler birbiriyle uyuşmuyor");
    }
}
