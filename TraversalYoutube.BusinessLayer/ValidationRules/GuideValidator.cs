using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.BusinessLayer.ValidationRules;
public class GuideValidator : AbstractValidator<Guide>
{
    public GuideValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen rehber adınız giriniz");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen rehber açıklamasını adınız giriniz");
        
    }
}
