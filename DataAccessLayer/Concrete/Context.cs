using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    //Context sınıfı veritabanına tabloları yansıtmak için kullanılır.
    public class Context:DbContext //Context sınıfı DbContext sınıfından türemiş oluyor. Yani context sınıfı kalıtsal yolla dbcontext in özelliklerine erişebiliyor. DbContext sınıfı entityframework içerisinde bulunur.
    {
        //Context sınıfı içerisinde bulunan özellikler birer tablo ismi olarak sql de karşılık bulacak. Bunu yapablimek için dataaccesslayer içerisine entityframework dahil edilmesi gerekir.
        public DbSet<About> Abouts { get; set; } //Database ile ilişkilendirilecek özellikler DbSet içerisine yazılır. Yani entity içerisine tanımlanan her bir sınıf burada dbset içerisine yazılır. About sınıfı başta altı kırmızı çizgili gelir çünkü başka bir katmandadır. Eğer başka bir katmandan bir özelliği, sınıfı vs. kullanmak istiyorsak kullanılacak katmana referans olarak eklemek gerekir. Dataaccesslayer içerisindeki references a sağ tıklanıp add reference denilerek EntityLayer bu katmana eklenmiş olur. Abouts bizim sql de veritabanımıza yansıyacak olan tablomuzun ismi.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }

    }
}
