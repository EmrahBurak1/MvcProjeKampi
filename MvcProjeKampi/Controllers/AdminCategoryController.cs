using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        CategoryManager cm = new CategoryManager(new EfCategoryDal()); //Parametre olarak EfCategoryDal yazmamızın nedeni bu yapıyı kullandığımızda ileride Ef yerine başka bir şey kullandığımız zaman kolayca değişiklik yapabilmemiz için.
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }

        [HttpGet] //Burada httpget attribute u ile sayfa yüklendiği zaman yapılacak işlemler belirtilir.
        public ActionResult AddCategory()
        {
            return View(); //Buradaki amaç sayfa yenilendiği zaman sadece sayfayı geri döndür anlamındadır. Aşağıdaki satırlarda ise httpPost attribute u ile butona tıklandığında ekleme işleminin yapılması sağlanır.
        }
        //Aşağıda ekleme işlemini yaptığımız zaman sayfa yüklenir yüklenmez ekleme işlemini yapıyor. Biz bunu istemiyoruz. Örneğin butona basıldığında ekleme işlemini yapmasını istiyoruz bunun için httpPost attribute u kullanılır. Yani sayfada bir şey post edildiği zaman ekleme işlemi gerçekleşir. Eğer sayfa yüklendiği zaman bir işlem yaptırmak istiyorsak httpGet attribute u kullanılır.
        [HttpPost]
        public ActionResult AddCategory(Category p) //Karegori eklemek için böyle bir actionresult oluşturduk.Daha sonra kategori tipinde bir p parametresi tanımladık.
        {

            //Validator içerisinde yazdığımız mesajları kullanıcıya göstermek için burada aşağıdaki kodları yazdık.
            CategoryValidator categoryValidator = new CategoryValidator(); //İlk olarak categoryValidator dan bir nesne türetilir.
            ValidationResult results = categoryValidator.Validate(p); //validationResult un kullanılabilmesi için using FluentValidation.Results; un eklenmesi gerekiyor. Bunun için de manage nugetpackage dan fluentvalidation paketi indirilmeli.
            //Yukarıdaki satırın anlamı result değişkeni categoryValidator sınıfında olan değerlere göre validasyon yap yani doğruluk kontrolünü yap anlamındadır.
            if (results.IsValid) //Eğer sonuç validasyona uygunsa yani sonuç geçerli ise anlamındadır.
            {
                cm.CategoryAdd(p); // Yani ekleme işleminin gerçekleştirilebilmesi için result dan gelen validasyanun doğru olması gerekiyor.
                return RedirectToAction("Index"); //Eğer sonuç sağlanıyorsa Indexe yönlendir anlamındadır.
            }
            else
            {
                foreach (var item in results.Errors) //Burada eğer validation koşulları sağlanmıyorsa hata mesajlarını göstericez.Bunun için foreach kullanıyoruz. ve resulttan gelen errorlardan bir döngü oluşturulur.
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);//Burada da modelin durumuna hataları ekle, bu hatalar da ilk olarak property nin ismi, ikincisi de hatanın kendisi oluyor.
                }
            }
            return View(); //Yukarıdaki koşulları yazdıktan sonra bu kodun devamını yorum yaptık.//RedirectToAction("GetCategoryList"); //Bunun amacı ekleme işlemi gerçekleştirildikten sonra parantez içerisinde tanımlanan methoda yönlendir anlamındadır.
        }

        //Kategory silme işlemi için tanımlandı. Bir viewa sahip değil sadece index üzerinde çağırılarak kullanılacak.
        public ActionResult DeleteCategory(int id)
        {
            var categotyvalue = cm.GetByID(id);
            cm.CategoryDelete(categotyvalue); 
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id) //Category güncelleme işlemini burada yapıyoruz. Silme işmeindeki gibi önce ID yi bulmak gerekiyor.
        {
            var categoryvalue = cm.GetByID(id);
            return View(categoryvalue); //Burada view döndürülürken değişken değerinide döndürüyoruz.
        }

        [HttpPost]
        public ActionResult EditCategory(Category p) //Category güncelleme işlemini burada yapıyoruz. Silme işmeindeki gibi önce ID yi bulmak gerekiyor.
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
