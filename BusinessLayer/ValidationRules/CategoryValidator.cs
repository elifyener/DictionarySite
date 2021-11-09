using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .WithMessage("Kategori adı boş bırakılamaz.")
                .MinimumLength(3)
                .WithMessage("Lütfen en az 3 karakter girişi yapın.")
                .MaximumLength(20)
                .WithMessage("Lütfen 20 karakterden fazla veri girişi yapmayın.");

            RuleFor(x => x.CategoryDescription)
                .NotEmpty()
                .WithMessage("Kategori açıklaması boş bırakılamaz.")
                .MinimumLength(100)
                .WithMessage("Lütfen en az 100 karakter girişi yapın.")
                .MaximumLength(200)
                .WithMessage("Lütfen 200 karakterden fazla veri girişi yapmayın.");
        }
    }
}
