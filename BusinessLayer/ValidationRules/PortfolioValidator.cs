using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {

        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje Adı Boş Geçilemez.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel Alanı Boş Geçilemez.");
            RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("Görsel2 Alanı Boş Geçilemez.");
            RuleFor(x => x.Ucret).NotEmpty().WithMessage("Fiyat Alanı Boş Geçilemez.");
            
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("En az 5 Karakterden oluşmak zorundadır.");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("En fazla 100 Karakterden oluşmak zorundadır.");

        }

    }
}
