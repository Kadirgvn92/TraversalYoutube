using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.DTOLayer.DTOs.AnnouncementDTOs;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.ValidationRules;
public class AnnouncementValidator : AbstractValidator<AnnouncementAddDTO>
{
    public AnnouncementValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen başlığı boş geçmeyin");
        RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen duyuru içeriğini boş geçmeyin");
        RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girmelisiniz");
        RuleFor(x => x.Title).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girmelisiniz");
        RuleFor(x => x.Content).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girmelisiniz");
        RuleFor(x => x.Content).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girmelisiniz");
    }
}

