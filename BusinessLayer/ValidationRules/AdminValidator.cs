using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.AdminUserName)
                .NotEmpty()
                .WithMessage("Mail adres boş bırakılamaz.")
                .EmailAddress()
                .WithMessage("Geçerli bir mail adresi giriniz.");

            RuleFor(x => x.AdminPassword)
                .NotEmpty()
                .WithMessage("Şifre boş bırakılamaz.");
                
        }
    }
}
