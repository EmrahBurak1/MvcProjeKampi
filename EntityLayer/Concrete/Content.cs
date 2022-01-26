using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //İçerik isimli bir sınıf oluşturduk. Burada bir yazıya ihtiyacımız var.
    public class Content
    {
        [Key]
        public int ContentID { get; set; } //İçerik ID si
        
        [StringLength(1000)]
        public string ContentValue { get; set; } //İçeriğin değeri yani metni
        
        //Tarih için herhangi bir kısıtlamaya gerek yok.
        public DateTime ContentDate { get; set; } //İçeriğin tarihi


        public bool ContentStatus { get; set; }

        //Burada heading ile kuracağımız ilişki için property oluşturmak gerekiyor.
        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; } //Bu şekilde başlık ile içiriği de ilişkili hale getirmiş olduk.

        //Writer ile ilişki kurmak için oluşturulan özellikler
        public int? WriterID { get; set; } //Burada soruişaretinin anlamı WriterID nullable olabilir anlamındadır. Yani boş bırakılabilir.
        public virtual Writer Writer { get; set; }
    }
}
