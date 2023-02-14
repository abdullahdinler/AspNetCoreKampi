using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator:AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı zorunludur.");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("İsim alanı zorunludur.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı zorunludur.");
        }
    }
}
