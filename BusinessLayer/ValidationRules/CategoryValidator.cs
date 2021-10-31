using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    //Validation doğrulama anlamına gelir. KAtegori için gerekli olan doğrulama kuralları burada belirtilecek. Validation kullanabilmek için bussiness layer katmanı içerisine manage nuget package dan fluent validation paketinin eklenmesi gerekiyor. ValidationRules veya fluent validation olarak geçer. Doğrulama kurallarıdır.
    public class CategoryValidator:AbstractValidator<Category> //Abstractvalidator sınıfından miras alacak. Abstractvalidator ın kullanılabilmesi için using FluentValidation eklenmesi gerekiyor.
    {
        //Validator sınıfları içerisinde kullanacağımız doğrulama kuralları bir constructor methodları içerisine yazıcaz.
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz"); //Rule for ifadesi bir kural için şunları yap anlamındadır. Parantez içerisinde yazan linq sorgusudur. x. diyerek abstractvalidator içerisine gönderdiğimiz T entity sine ait property lere erişebiliyoruz. Daha sonra parantez dışındakiler de doğrulama kuralıdır. Örneğin .notEmpty boş olamaz anlamındadır. Daha sonra yazılan .withMessage ile de kullanıcıya mesaj verebiliyoruz.
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı boş geçemezsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız"); //minimum karakter uzunluğu 3 olacak anlamındadır daha yüksek girilirse uyarı mesajı kullanıcıya gösterilir.
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla geğer girişi yapmayın");
        }
    }
}
