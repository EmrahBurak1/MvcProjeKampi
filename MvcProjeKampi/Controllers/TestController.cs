using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            //Burada yeni bir controller olusturduk. Projemizde her bir bolum farklı kontroller olarak yazilir. Ornegin kullanicilar ayrı, yazilar ayri, basliklar ayri, admin ayri bir controller olarak olusturulur.
            //Index icin bir view olusturmadan once layout olusturmak istiyoruz. Bunun icin shared klasörüne sag tiklanip add view denir. Use a layout tiki kaldirilinca herhangi bir layout kullanmicak anlamina gelir ve kendisi bir layout olur. 
            return View();
        }

        public ActionResult Test2()
        {
            return View();
        }
    }
}