using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    //Burada yazılan ifadeler daha sonra genel kullanım için GenericRepository 'e taşındı.
    //IcategoryDal içerisinde tanımladığımız CRUD operasyonlarını kullanabilmek için CategoryRepository isimli bir sınıf oluşturduk ve kalıtsal yollarla bu interfaceden ilgili operasyonları çektik. İmplement ettiğimizde tüm operasyonlar buraya aktarılmış olur.
    public class CategoryRepository : ICategoryDal
    {

        Context c = new Context(); //Context sınıfını veritabanına tabloları yansıtmak için kullanıyorduk. Bu nedenle burada yeni bir nesne oluşturduk.
        DbSet<Category> _object; //Context sinifi içerisinde değerler DbSet türünde tutulmuştu buradada aynı şekilde değerler DbSet içerisinde tutulacak. _object ise nesne olarak düşünülebilir. 

        public void Delete(Category p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public void Insert(Category p)
        {
            _object.Add(p); //p isimli parametreden gelen değeri object içerisine eklemiş oluyor.
            c.SaveChanges(); //Ekleme işlemi bittikten sonra context için ürettiğimiz nesnede değişiklikleri kaydet denir.
        }

        public List<Category> List()
        {
            return _object.ToList(); //ToList methodu entityframeworkte verileri listelemek için kullanılır. 
        }

        public List<Category> List(Expression<Func<Category, bool>> filter) //Sonradak ekledik. 
        {
            throw new NotImplementedException();
        }

        //Entityframeworkte eklemek için add methodu, silme için remove methodu kullanılır. Güncelleme için farklı bir yöntem kullanılıyor. Bulma işlemi için find kullanılır.
        public void Update(Category p)
        {
            c.SaveChanges(); //Güncelleme işleminde tek yapılacak şey değişiklikleri kaydetmektir. Çünkü zaten güncellemeden önce yeni hal yansıtılır. 
        }
    }
}
