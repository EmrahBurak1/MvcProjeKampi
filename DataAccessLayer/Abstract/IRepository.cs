using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //Aşağıda bulunan methodları her bir dal içerisinde tek tek yazmamak için burada IRepository isimli bir interface tanımladır ve ilgili CRUD işlemlerini buraya ekledik. Artık diğer dallar buradaki methodları miras alacak. Yani kalıtım yoluyla buradaki methodlar ilgili yerlere aktarılacak.
    //Burada IRepository nin avantajı biz yeni bir öge ekliceğimiz zaman sadece buraya eklememiz yeterli olacak. Tek tek her birine ayrı ayrı eklememize gerek kalmayacak.
    
    public interface IRepository<T> //Buradaki T değeri bizim türümüzü temsil eder. ICategoryDal içerisinde parametre olarak category almıştık. Her biri için tek tek varlık ismiyle parametre oluşturmamak için genel isimde burada T isimli tür ismi yazılır. T örnektir herhangi bir yazı yazılabilir.
    {
        List<T> List();

        void Insert(T p); //T den parametre al anlamındadır T hangi varlığa karşılık gelecekse onun içerisindeki propertileri p parametresi ile kullanabiliyoruz.

        //Sildiriceğimiz değeri buldurmak için aşağıdaki kodu ekledik
        //En altta bulunan list(expression... ile arasındaki fark. Generic repositoyr içerisinde tanımlandığı gibi burada singleordefault methodu ile tek bir değer döndürüyoruz. Aşağıdaki list ile bütün bir listeyi döndürüyoruz. Örneğin İsmi ali olan yazarları döndürmek istersek aşağıdaki list ifadesi kullanılır veya ID si 5 olan kullanıcıyı döndürmek istersek buradaki singleordefault ile ilgili olan ifade kullanılır.
        T Get(Expression<Func<T, bool>> filter); //linq syntax'ı yapıldı. IRepository içerisinde get isimli bir method tanımlandı. Get methodunun türü T dir. Yani entitydir.
       
        void Delete(T p);

        void Update(T p);

        List<T> List(Expression<Func<T, bool>> filter); //Örnek olması açısından böyle bir şartlı listeleme işlemi oluşturduk. İçerisine yazdığımız ifade link için bir sorgu işlemidir ezberlemye gerek yoktur. Araştırılarak bulunabilir. Şartlı methodun amacı örneğin ismi sadece Ali olanları getirmek istiyorsak bu methodu kullanmamız gerekir.
    }
}
