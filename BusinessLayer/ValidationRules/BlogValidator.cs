using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
   public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Blog içeriği boş gecilemez alanı boş geçilemez.").MinimumLength(100).WithMessage("İcerik alanı en az 100 karekter olması lazım.");
            RuleFor(x => x.ThumbnailImage).NotEmpty().WithMessage("Küçük resim alanı boş geçilemez.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Büyük resim alanı boş geçilemez.");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Başlık alanı boş geçilemez.");
        }
    }
}
