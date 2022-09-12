using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator:AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Proje alanı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Proje alanı 5 karakterden küçük olamaz");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Proje alanı 100 karakterden büyük olamaz");
            RuleFor(x=>x.ShortImageUrl).NotEmpty().WithMessage("Küçük resim alanı boş geçilemez");
            RuleFor(x=>x.LongImageUrl).NotEmpty().WithMessage("Büyük resim alanı boş geçilemez");
            RuleFor(x=>x.Price).NotEmpty().WithMessage("Fiyat alanı boş geçilemez");
            RuleFor(x=>x.Value).NotEmpty().WithMessage("Değer alanı boş geçilemez");
        }
    }
}
