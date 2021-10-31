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
        
        [StringLength(100)]
        public string WriterImage { get; set; }
        
        [StringLength(50)]
        public string WriterMail { get; set; }
        
        [StringLength(20)]
        public string WriterPassword { get; set; }

        //Yazar ile başlık arasında da bir ilişki oluşturmak istiyoruz. Çünkü başlığı hangi yazarın yazdığını bilmek istiyoruz.
        public ICollection<Heading> Headings { get; set; }

        //İçerik ile yazar arasında ilişki kurmak için kullanılan özellikler
        public ICollection<Content> Contents { get; set; }
    }
}
