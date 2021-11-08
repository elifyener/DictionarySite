using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterLoginValidator : AbstractValidator<Writer>
    {
        public WriterLoginValidator()
        {
            RuleFor(x => x.WriterMail)
                .NotEmpty()
                .WithMessage("Mail adres boş bırakılamaz.")
                .EmailAddress()
                .WithMessage("Geçerli bir mail adresi giriniz.");

            RuleFor(x => x.WriterPassword)
                .NotEmpty()
                .WithMessage("Şifre boş bırakılamaz.");
        }
    }
}
