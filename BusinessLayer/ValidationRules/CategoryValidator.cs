using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori isim alanı boş gecilemez.").MaximumLength(30)
                .WithMessage("Karekter uzunluğu 30 karekter fazla olamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Kategori acıklama alanı boş gecilemez.").MaximumLength(60)
                .WithMessage("Karekter uzunluğu 60 karekter fazla olamaz.");
        }
    }
}
