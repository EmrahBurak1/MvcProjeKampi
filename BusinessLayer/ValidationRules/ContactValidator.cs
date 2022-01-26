using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact> //Abstractvalidator sınıfından miras alacak. Abstractvalidator ın kullanılabilmesi için using FluentValidation eklenmesi gerekiyor.
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu adını boş geçemezsiniz"); //Rule for ifadesi bir kural için şunları yap anlamındadır. Parantez içerisinde yazan linq sorgusudur. x. diyerek abstractvalidator içerisine gönderdiğimiz T entity sine ait property lere erişebiliyoruz. Daha sonra parantez dışındakiler de doğrulama kuralıdır. Örneğin .notEmpty boş olamaz anlamındadır. Daha sonra yazılan .withMessage ile de kullanıcıya mesaj verebiliyoruz.
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adını boş geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız"); //minimum karakter uzunluğu 3 olacak anlamındadır daha yüksek girilirse uyarı mesajı kullanıcıya gösterilir.
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.Subject).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla geğer girişi yapmayın");
        }
    }
}
