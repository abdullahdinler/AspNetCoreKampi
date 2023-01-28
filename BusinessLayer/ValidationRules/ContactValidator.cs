using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("İsim alanı boş geçilemez").MinimumLength(3).WithMessage("İsim alanı en az 3 karekter olması lazım.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez").EmailAddress().WithMessage("Geçersiz mail adresi.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj alanı boş geçilemez").MinimumLength(30).WithMessage("Mesaj uzunluğu en az 30 karekter olması lazım.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Başlık alanı boş geçilemez");
        }
    }
}
