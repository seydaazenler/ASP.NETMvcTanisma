using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMVCIntroduction.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

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
        public ActionResult Deneme()
        {
            ViewBag.Ad = "Betül";
            //ViewData
            ViewData["Ad"] = "Ali";
            //ViewData ile ViewBag birbirinin aynısıdır.Sadece yazımları farklı
            //Ekranda ViewBag Ad içinde Ali'yi göreceğiz.
            //Çünkü ViewBag'in taşıdığı ad değişkeni 37.satırda yenide set edildi.
            ViewData["Soyad"] = "Akşan";
            TempData["Adiniz"] = "Betül";

            return View();
        }
    }
}
       