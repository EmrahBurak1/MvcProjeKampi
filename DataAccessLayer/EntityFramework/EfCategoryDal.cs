using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryDal: GenericRepository<Category>, ICategoryDal //EfCategoryDal Generic repository den miras alacak. İçerisindeki parametre değeri de category olacak. Virgulden sonra yazılan ICategoryDal ise ayrıca ICategoryDaldaki değerleride al anlamındadır. Bu şekilde katmanları, katmanlar arasındaki sınıfları birbiri ile haberleştirerek her katmanın her, her sınıfın içindeki komut sadece kendisine ait işlemleri gerçekleştirsin istiyoruz.
    {
        //Yani yukarıda yazdığımız komutta EfCategoryDal sınıfı GenericRepository içerisinde bulunan Category sınıfındaki verileri kullanabilecek anlamındadır.

    }
}
