using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz."); 
            RuleFor(x => x.MessageSubject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz."); 
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı geçemezsiniz.");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Lütfen geçerli bir mail girin.");
            RuleFor(x => x.MessageSubject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın.");
            RuleFor(x => x.MessageSubject).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla giriş yapmayın.");
        }
    }
}
