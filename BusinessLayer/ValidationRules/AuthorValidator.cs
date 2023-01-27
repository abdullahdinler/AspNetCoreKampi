using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez.");

            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş gecilemez").MinimumLength(10)
                .WithMessage("Mail uzunluğu en az 10 karekter oması lazım").EmailAddress()
                .WithMessage("Lütfen mail formatında giriniz.");

            RuleFor(x => x.About).NotEmpty().WithMessage("Hakkımda kısmı boş geçilemez").MinimumLength(30)
                .WithMessage("Hakkımda kısmı en az 30 karekter olması lazım");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez").MinimumLength(8)
                .WithMessage("Şifre 8 karakterden küçük olamaz.").MaximumLength(16)
                .WithMessage("Şifre 16 karakterden büyük olamaz.").Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).+$")
                .WithMessage("Parolanız en az bir büyük harf, en az bir küçük harf ve en az 1 sayı içermelidir.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Resim alanı boş geçilemez");
        }

    }
}
