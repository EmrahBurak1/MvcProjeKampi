using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{

    public interface ICategoryDal:IRepository<Category>
    {

        ////Aşağıdaki kullanım yanlıştır bunun yerine IRepository interface i oluşturulur ve CRUD işlemleri methodlar onun içerisinde oluşturulur. Yani tek tek her biri için ayrı ayrı CRUD operasyonları yazılmaz.
        ////bu interface içerisine CRUD operasyonlarını birer method olarak tanımlıcaz. CRUD- create,read,update,delete

        ////Bir method tanımlanırken önce türü sonra method ismi yazılıp parantez açılıp kapanır. 
        ////ilk olarak listeleme işlemi yapmak istiyoruz bunun için de bir list oluşturmamız gerekiyor. Methodumuzun türü list ismi ise List oluyor. Küçük büyük içerisine listelenecek entity yazılmalı.
        //List<Category> List(); //Türü list ismi de List olan bir method tanımladık.

        ////Sonraki işlem ekleme işlemi olsun.
        //void Insert(Category p); //Ekleme işlemi yapabilmek için parametre ataması yapmak gerekiyor. Yani Category türünde p parametresi tanımlandığında bunun anlamı p parametresi yardımı ile category içerisindeki propertylere erişebileceğimiz anlamına gelir.

        ////Güncelleme işlemi için 
        //void Update(Category p);

        ////Silme işlemi için
        //void Delete(Category p);
    }
}
