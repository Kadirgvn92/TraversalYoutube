using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.DTOLayer.DTOs.AnnouncementDTOs;

namespace TraversalYoutube.BusinessLayer.ValidationRules;
public class AnnouncementUpdateValidator : AbstractValidator<AnnouncementUpdateDTO>
{
    public AnnouncementUpdateValidator()
    {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen başlığı boş geçmeyin")
                                 .MinimumLength(5).WithMessage("Lütfen en az 5 karakter girmelisiniz")
                                 .MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girmelisiniz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen duyuru içeriğini boş geçmeyin")
                                   .MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girmelisiniz")
                                   .MinimumLength(5).WithMessage("Lütfen en az 5 karakter girmelisiniz");
    
    }
}
