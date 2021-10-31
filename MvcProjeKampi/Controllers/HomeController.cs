using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Proje olustururken asp.net mvc secildiğinde solution icinde MvcProjeKampi isimli proje olusuyor. Buna user interface veya presentation katmanı deniyor.
namespace MvcProjeKampi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() //index methodu listeleme işlemi icin kullaniliyor.
        {
            return View();
        }
        //Controller tarafında methodlar varsa bunun view tarafında karşılığı olmalı.
        public ActionResult About() 
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test() //ActionResault tanimlarsak bir de geridınus degeri olmasi gerekiyor. Test action resoultu olusturulduktan sonra view olusturulması icin test uzerine sag tiklanip addview denir.
        {
            //Add view dedikten sonra use a layout bolumunden layout secilmesi gerekiyor. Master page yapisi mvc ile beraber layout olarak isimlendiriliyor. Uc noktaya basarak proje icerisindeki layout secilir. Bu da views icerisinde bulunan shared klasorunun icindedir. Bu projede layout bolumu nav bar olarak tanimlanmis biz de o navbarı kullanabilmek icin olusturdugumuz viewe layout eklememiz gerekiyor.
            return View();
        }
    }
}