﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName)
                 .NotEmpty()
                 .WithMessage("Başlık adı boş bırakılamaz.")
                 .MaximumLength(50)
                 .WithMessage("Lütfen en fazla 50 karakter giriniz.")
                 .MinimumLength(3)
                 .WithMessage("Lütfen en az 3 karakter giriniz.");

        }
    }
}
