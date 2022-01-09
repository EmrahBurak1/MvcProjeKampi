using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            //Her bir kategory için tek tek textboxfor kullanmak yerine dropdownlist kullanmak daha mantıklı bu nedenle aşağıdaki yapıyı kullandık.
            //linq sorgusuyla dropdownlist doldurulur.
            List<SelectListItem> valuecategory = (from x in cm.GetList() //cm deki bütün veriler getirilir.
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            //Üstte bulunan valuecategory değişkeni kategori ismini ve kategori idsini tutuyor.

            List<SelectListItem> valuewriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                   { 
                                                      Text  = x.WriterName + " " + x.WriterSurname,
                                                      Value = x.WriterID.ToString()
                                                   }).ToList();

            ViewBag.vlc = valuecategory; //viewbag yardımı ile controller tarafındaki veri view'e aktarılır.
            ViewBag.vlw = valuewriter; //vlw ismi bizim belirlediğimiz bir isim değişebilir.
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate= DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index"); 
        }

        public ActionResult ContentByHeading()
        {
            return View();
        }
    }
}