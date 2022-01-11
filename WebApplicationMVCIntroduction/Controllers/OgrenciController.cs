using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMVCIntroduction.Models;

namespace WebApplicationMVCIntroduction.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        public ActionResult Listele()
        {
            List<Ogrenci> ogrList = Ogrenci.OgrenciyiGetir();
            return View(ogrList); //view içerisinde öğrenci modelini göndeririz
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Ogrenci ogr)
        //ogrenci ogr parametresi dışarıdan gelecek
        {
            //veritabanımız olmadığı için ID'yi kendimiz atadık
            var tumOgrler = Ogrenci.OgrenciyiGetir();
            ogr.Id = tumOgrler.Count + 1;

            //öğrenci ekleme kısmı
            Ogrenci.OgrenciListesi.Add(ogr);
            //ekleme yapıldıktan sonra Listele Action'ına redirect olmalıyız
            //bulunduğumuz Actiondan farklı bir Action'a gitmeyi sağlar

            return RedirectToAction("Listele");
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            //gelen id>0 ise benim listemde onu bul ve view() ile gönder
            if (id > 0)
            {
                Ogrenci bulunanOgr = Ogrenci.OgrenciListesi.FirstOrDefault(x => x.Id == id);
                return View(bulunanOgr);
            }
            return View();
        }
        [HttpPost]
        public ActionResult Guncelle(Ogrenci ogr)
        {
            Ogrenci guncellenecekEskiOgr = Ogrenci.OgrenciListesi.FirstOrDefault(x => x.Id == ogr.Id);
            if (guncellenecekEskiOgr != null)
            {
                //öğrenciyi buldun, bulduğun bu öğrenciye yeni değerleini ata
                //eski bilgiler sağda, yeni güncellenecek bilgiler solda
                guncellenecekEskiOgr.Ad = ogr.Ad;
                guncellenecekEskiOgr.Soyad = ogr.Soyad;
                guncellenecekEskiOgr.DogumTarihi = ogr.DogumTarihi;

            }
            return RedirectToAction("Listele");
        }

        [HttpGet]
        public ActionResult Sil(int id)
        {
            var silinecekOgr = Ogrenci.OgrenciListesi.FirstOrDefault(x => x.Id == id);
            return View(silinecekOgr);
        }

        [HttpPost]
        public ActionResult Sil(Ogrenci ogr)
        {
            if (ogr.Id > 0)
            {
                Ogrenci.OgrenciListesi.Remove(ogr);
            }
            return RedirectToAction("Listele");
        }
         [HttpPost]
        public ActionResult Sil2(Ogrenci ogr)
        {
            if (ogr.Id >0)
            {
                Ogrenci.OgrenciListesi.Remove(ogr);
                return Json(new { success = true });
            }
            return Json(new { success = false, error = "Beklenmedik hata oluştu!" });
        }
    }
}