using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class NewsLatterValidator:AbstractValidator<NewsLetter>
    {
        public NewsLatterValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Meil alanı boş geçilemez").EmailAddress()
                .WithMessage("Girdiğiniz mail hatalı");
        }
    }
}
