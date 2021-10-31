using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService // Artık ICategoryService e bağlı olarak çalışacak yani kalıtsal yollarla IcategoryService içerisindeki özellikleri içine al
    {
        //Normalde bu şekilde tanımladığımızda düzgün çalışıyor fakat solid prensiplerine uygun olmuyor katmanlı mimarinin gerekliliğinden dolayı buradaki ifadeler interface içerisine taşındı. 
        /*
        GenericRepository<Category> repo = new GenericRepository<Category>();

        public List<Category> GetAllBL() //Bussinass layer da oluşturulmuş bir method. Bütün ürünleri listelemek için oluşturuldu. Genericrepository içerisine bir T değeri istiyor, category için istediğimiz için category yazılır. GenericRepository den türettiğimiz repo nesnesi ile genericrepository içerisinde bulunan listeleme işlemine erişebiliyoruz.
        {
            return repo.List();
        }
        public void CategoryAddBL(Category p)
        {
            if (p.CategoryName=="" || p.CategoryName.Length<=3 || p.CategoryDescription == "" || p.CategoryName.Length>=51) //p ile category sinifina ait özelliklere ulaşabiliyoruz. Yani category tablosuna ait sutunlar olarak dusunulebilir.
            {
                //hata mesajı
            }
            else
            {
                repo.Insert(p); //Eğer yukarıdaki koşulu sağlamayıp hata mesajına düşmüyorsa burada p parametresinden gelen değeri repoya ekleyecek. Ekleme işlemi de genericrepository içerisinde bulunan insert methodu ile yapılıyor.
            }
        }
        */

        ICategoryDal _categorydal;

        public CategoryManager(ICategoryDal categorydal) //Constructor methodunu kısa yoldan public class CategoryManager yazan yerde CategoryManager üzerine tıklayıp ctrl nokta diyerek generate constructor diyebiliriz.
        {
            _categorydal = categorydal;
        }

        public void CategoryAdd(Category category) //Daha sonradan Interface içerisine ekleyip buraya implement ettik. Validation olayını aşağıdaki yanlış kullanımdan çıkarıp burada doğrusunu yazdık.
        {
            _categorydal.Insert(category);
            //Validation tarafında mesajları gösterebilmek için controller tarafında kod yazılır.
        }

        //Burada ürettigimiz _categorydal nesnesine değer ataması için GenericRepository kullanabiliriz fakat asıl olay bussiness tarafında olabildiğince newlemekten kaçınmak ve projedeki bağımlılığı minimize etmek. Bu olay dependency injection olarak geçiyor. 

        public List<Category> GetList()
        {
            //Burada listeleme işlemi ICategoryDal dan yapılacak. ICategoryDal interface i ise IRepository den miras alıyor. IRepository interface i içerisinde de bizim methodlarımız var. Bu methodların içini de DataAccessLayer içerisinde bulunan Concrete klasörü içindeki repository klasörünün içinde bulunan GenericRepository de doldurduk.

            //Burada bir değer döndürebilmek için öncelikle ICategoryDal dan bir nesne türetmemiz gerekiyor.
            return _categorydal.List();
            //Bu şekilde biz categorymanager sınıfı içerisinde genericRepository i newlemeden genericRepositye bağımlılığı minimize ederek genericRepository içerisindeki değerlere erişmiş olduk.
        }

        //public void CategoryAddBL(Category p) //Burayı yanlış kullanımı göstermek için yazdık. Bu şekilde doğrulama işlemi yapmak yerine validation kullanmak daha doğrudur.
        //{
        //    if (p.CategoryName == "" || p.CategoryStatus == false || p.CategoryName.Length <=2)
        //    {
        //        //hata mesajı
        //    }
        //    else
        //    {
        //        _categorydal.Insert(p);
        //    }
        //}
    }
}
