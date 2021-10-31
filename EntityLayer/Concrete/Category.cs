using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }
        
        [StringLength(200)]
        public string CategoryDescription { get; set; }
        
        //Status için herhangi bir kısıtlama yapmamıza gerek yok.
        public bool CategoryStatus { get; set; } //İliskili tablolarda silme islemi kullanmicaz durumu aktif ya da pasif edicez.



        //Category sınıfı ile Heading sınıfı arasında ilişki kurmak istiyoruz.
        public ICollection<Heading> Headings { get; set; } //Burada bir özellik tanımlandı. Özelliğin türü bir koleksiyon. Yani koleksiyon türündeki interface oluyor. Bizim amacımız bu sınıfa ait bir koleksiyon oluşturmak. ICollection yazinca küçüktür büyüktür parantezi içinde bizden ilişki kurmak istediğimiz sınıfın ismini istiyor. Biz heading ile ilişki kurmak istediğimiz için heading yazdık.

        
    }
}
