using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        
        [StringLength(50)]
        public string WriterName { get; set; }
        
        [StringLength(50)]
        public string WriterSurname { get; set; }
        
        [StringLength(250)]
        public string WriterImage { get; set; }

        [StringLength(100)]
        public string WriterAbout { get; set; } //Bu satırları sonradan ekledik aşağıdaki password satırınıda uzunluğunu 200 olarak değiştirdik bu değişiklikleri veri tabanına yansıtmak için migration kullanılır. Package Manager Console sayfasına gidilir. add-migration mig_writer_edit yazılır entera basılır add-migration tyazıldıktan sonra mig-writer-edit in herhangi bir anlamı yoktur herhangi bir şey yazılabilir. Hata verirse doğru katmanda olmadığımız için default project bölümünden context in olduğu katman olan dataaccesslayer seçilir. Daha sonra migration oluştuktan sonra up me down methodları migration içerisinde otomatik oluşur ve son olarak package manager console üzerine update-database yazılarak değişiklikler veri tabanına uygulanır.

        [StringLength(200)]
        public string WriterMail { get; set; }
        
        [StringLength(200)]
        public string WriterPassword { get; set; }

        [StringLength(50)]
        public string WriterTitle { get; set; }

        public bool WriterStatus { get; set; } //Projelerde genelde silme işlemi yapılmaz onun yerine aktif ve pasif yapılır.

        //Yazar ile başlık arasında da bir ilişki oluşturmak istiyoruz. Çünkü başlığı hangi yazarın yazdığını bilmek istiyoruz.
        public ICollection<Heading> Headings { get; set; }

        //İçerik ile yazar arasında ilişki kurmak için kullanılan özellikler
        public ICollection<Content> Contents { get; set; }
    }
}
