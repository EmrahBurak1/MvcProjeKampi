using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    //Burada kod tekrarından kurtulmak için her bir repository de ayrı ayrı varlıkları girmek yerine bu şekilde genericler kullanılarak daha düzenli bir hale getirilebilir ve kod tekrarından kurtulmuş olunur.
    public class GenericRepository<T> : IRepository<T> where T : class  //Burada IRepository den miras alacak. Ayrıca bir de şart koyuyoruz. where T : class ifadesi bizim göndereceğimiz T değeri bir class olmalı anlamındadır.
    {

        Context c = new Context(); //Context sınıfını veritabanına tabloları yansıtmak için kullanıyorduk. Bu nedenle burada yeni bir nesne oluşturduk.
        
        //Normalde her bir repositoryi ayrı ayrı oluşturup aşağıdaki T yerine ilgilli Entity yazılırdı fakat buradaki yapıyla T değişkeni ile hepsine erişilebiliyor.
        DbSet<T> _object; //Context sinifi içerisinde değerler DbSet türünde tutulmuştu buradada aynı şekilde değerler DbSet içerisinde tutulacak. _object ise nesne olarak düşünülebilir. T değerine karşılık gelen sinifları tutmak için kullanılır.

        //Biz burada T değerine karşılık gelen sınıfı bulmak için Constructor dan yararlanırız. Yani yapıcı method kullanılır. Bu şekilde object içerisine değer ataması yapılır.
        public GenericRepository() //ctor yazıp tab tab yapılınca constructor method oluşmuş olur.
        {
            //_object nesnesine değer ataması yapmak için constructor method kullanmak gerekiyor bu nedenle constructor method tanımlandı.
            _object = c.Set<T>(); //Burada object içerisine değer ataması yapılır. Yani object değeri context'e bağlı olarak gönderilen T değeri olacak. Yani bizim dışarıdan gönderdiğimiz T değerini object içerisine almış olduk.
        }

        public void Delete(T p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public void Insert(T p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            //Listeleme işleminde bir değeri return etmek gerekiyor.
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList(); //Şartlı listelemede filter ile ne gönderirsek ona göre listeleme yapacak anlamındadır.
        }

        public void Update(T p)
        {
            c.SaveChanges();
        }
    }
}
