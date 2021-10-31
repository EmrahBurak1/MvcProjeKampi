using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        //Sınıflar içerisindeki bütün Id lere primary key ataması yapmak gerekiyor bunun için aşağıdaki key anahtar sözcüğü kullanılır. Key anahtar sözcüğünü direkt kullandığımızda altı kırmızı çizili gelir. Bunu gidermek için projeye entityframework paketi dahil edilmelidir.
        //dahil etmek için entitylayer sınıfına sağ tıklanıp manage nuget packet den entity framework seçilir. dahasonra key üzerindeki ampule basılarak dataannotation projeye dahil edilir.
        [Key] //Key sözcüğü ile AboutId için primarykey olarak atanmış oldu.
        public int AboutID { get; set; }
        
        [StringLength(1000)] //Bu ifade ile aboutdetails1 'in uzunluğu max 1000 olarak seçildi.
        public string AboutDetails1 { get; set; } //Hakkında kisminda kullanacağımız temada iki farklı nokta var. Bu nedenle iki ayrı detay oluşturduk.

        [StringLength(1000)]
        public string AboutDetails2 { get; set; }

        [StringLength(100)]
        public string AboutImage1 { get; set; } //Resimleri sunucuya yüklenmez doğru bir yöntem değil. Resimlerin dosya yolu veritabanına çekilir.
        
        [StringLength(100)]
        string AboutImage2 { get; set; }

    }
}
