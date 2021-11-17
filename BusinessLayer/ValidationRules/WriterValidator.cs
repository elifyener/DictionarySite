using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            // /Writer/EditWriter/ - /Writer/AddWriter/
            RuleSet("Names", () =>
            {
                RuleFor(x => x.WriterName)
                 .NotEmpty()
                 .WithMessage("Yazar adı boş bırakılamaz.")
                 .Length(2, 50)
                 .WithMessage("Lütfen en az 2 en fazla 50 karakter giriniz.");

                RuleFor(x => x.WriterSurname)
                     .NotEmpty()
                     .WithMessage("Yazar soyadı boş bırakılamaz.")
                     .Length(2, 50)
                     .WithMessage("Lütfen en az 2 en fazla 50 karakter giriniz.");
            });

            // /Login/WriterLogin/
            RuleSet("Mail", () =>
            {
                RuleFor(x => x.WriterMail)
                    .NotEmpty()
                    .WithMessage("Mail adres boş bırakılamaz.")
                    .EmailAddress()
                    .WithMessage("Geçerli bir mail adresi giriniz.");
            });

            RuleSet("PasswordLogin", () =>
            {
                RuleFor(x => x.WriterPassword)
                .NotEmpty()
                .WithMessage("Şifre boş bırakılamaz.");
            });

            RuleSet("Passwords", () =>
            {
                RuleFor(x => x.WriterPassword)
                .NotEmpty()
                .WithMessage("Şifre boş bırakılamaz.")
                .MinimumLength(6)
                .WithMessage("Şifreniz en az 6 karakter içermeli.")
                .Matches(@"[A-Z]+")
                .WithMessage("Şifreniz en az bir büyük harf içermelidir.")
                .Matches(@"[a-z]+")
                .WithMessage("Şifreniz en az bir küçük harf içermelidir.")
                .Matches(@"[0-9]+")
                .WithMessage("Şifreniz en az bir rakam içermelidir.")
                .Matches(@"[\!\?\*\.]+")
                .WithMessage("Şifren (!? *.) karakterlerden birini içermelidir.");

                RuleFor(x => x.WriterConfirmPassword)
                    .NotEmpty()
                    .WithMessage("Lütfen şifreyi tekrar giriniz.")
                    .Equal(x => x.WriterPassword)
                    .WithMessage("Şifreler uyuşmuyor.");
            });

            // /Writer/EditWriter/ - /Writer/AddWriter/
            RuleSet("About", () =>
            {
                RuleFor(x => x.WriterAbout)
                    .MaximumLength(100)
                    .WithMessage("Lütfen en fazla 100 karakter giriniz.");
            });

            
        }
    }
}
