using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz"); //Rule for ifadesi bir kural için şunları yap anlamındadır. Parantez içerisinde yazan linq sorgusudur. x. diyerek abstractvalidator içerisine gönderdiğimiz T entity sine ait property lere erişebiliyoruz. Daha sonra parantez dışındakiler de doğrulama kuralıdır. Örneğin .notEmpty boş olamaz anlamındadır. Daha sonra yazılan .withMessage ile de kullanıcıya mesaj verebiliyoruz.
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmını boş geçemezsiniz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan kısmını boş geçemezsiniz");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapınız"); //minimum karakter uzunluğu 3 olacak anlamındadır daha yüksek girilirse uyarı mesajı kullanıcıya gösterilir.
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla geğer girişi yapmayın");
        }
    }
}
