using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    //Entity layer varlık katmanı, İçerisinde concrete ve abstract klasörleri var. Somut sınıflar concrete içerisinde, soyut sınıflar abstract içerisinde kullanılıyor.
    //Heading isimli bir class tanımladık. Başlık olarak düşünebiliriz. Başlığın farklı farklı özellikleri olabilir bu da kısa yoldan prop ile oluşturulur. Prop yazıp tab tab yapılınca özellik oluşmuş olur ve ona isim verilir.
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; } //BaşlıkID si
        
        [StringLength(50)]
        public string HeadingName { get; set; } //Başlık İsmi
        public DateTime HeadingDate { get; set; } //Başlık Tarihi


        //Category ile kurmak istediğimiz ilişki için kategory sınıfı içinde koleksiyon tanımlamıştık. Burada da  birkaç özellik girmek gerekiyor.
        public int CategoryID { get; set; } //Category sınıfında neye göre ilişkilendireceğimizi burada belirtiyoruz. Yani Heading tablomuz içerisinde CategoryId isimli bir sutun olacak.
        public virtual Category Category { get; set; } //Burada da category türünde bir proporty oluşturduk. Virtual'ın amacı da ilgili sınıftan bir değer alacağı anlamına gelir.

        //Bunun dışında heading ile de content ilişkili.
        public ICollection<Content> Contents { get; set; } //Burada da bu sınıfımızın content ile ilişkili olacağı belirtilir.

        //Başlık ile yazar arasında kuracağımız ilişki için aşağıdaki özelliklerin tanımlanması gerekiyor.
        public int WriterID { get; set; } //Başlığı açan yazarı bulmak için writerId ye ihtiyacımız var.
        public virtual Writer Writer { get; set; }
    }
}
