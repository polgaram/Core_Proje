using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ExperienceValidator : AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(1).WithMessage("Ad alanı 1 karakterden küçük olamaz");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Ad alanı 100 karakterden büyük olamaz");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez");
            RuleFor(x => x.Title).MinimumLength(1).WithMessage("Başlık alanı 1 karakterden küçük olamaz");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Başlık alanı 100 karakterden büyük olamaz");

            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih alanı boş geçilemez");
            RuleFor(x => x.Date).MinimumLength(4).WithMessage("Tarih alanı 4 karakterden küçük olamaz");
            RuleFor(x => x.Date).MaximumLength(50).WithMessage("Tarih alanı 50 karakterden büyük olamaz");


            RuleFor(x => x.ImageUrl).NotNull().WithMessage("Resim alanı boş geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim alanı boş geçilemez");






            //RuleSet("clientside", () => {
            //    RuleFor(x => x.ImageUrl).NotNull().WithMessage("Resim alanı boş geçilemez");
            //});

        }
    }
}
