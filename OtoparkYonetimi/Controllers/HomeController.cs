using OtoparkYonetimi.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;

namespace OtoparkYonetimi.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        OtoparkYonetimiEntities db = new OtoparkYonetimiEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "A,P")]
        [HttpGet]
        public ActionResult YeniKayit()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "A,P")]
        public ActionResult YeniKayit(Tbl_Kisiler k1)
        {
            db.Tbl_Kisiler.Add(k1);
            db.SaveChanges();
            return RedirectToAction("Cikis");
        }
        [Authorize(Roles = "A,P")]
        public ActionResult Cikis() 
        {
            var liste = db.Tbl_Kisiler.ToList();
            return View(liste);
        }

        public ActionResult Sil(int id)
        {
            db.Tbl_Kisiler.Remove(db.Tbl_Kisiler.Find(id));
            db.SaveChanges();
            return RedirectToAction("Cikis");
        }

        public ActionResult KisiGetir(int id) 
        {
            var kisi = db.Tbl_Kisiler.Find(id);
            return View("KisiGetir", kisi);
        }
        public ActionResult KisiGuncelle(Tbl_Kisiler k1) 
        {
            var kisi = db.Tbl_Kisiler.Find(k1.KisiId);
            kisi.TcKimlikNo = k1.TcKimlikNo;
            kisi.Ad = k1.Ad;
            kisi.Soyad = k1.Soyad;
            kisi.CepTelefonu = k1.CepTelefonu;
            kisi.Adres = k1.Adres;
            db.SaveChanges();
            return RedirectToAction("Cikis");
        }
    }
}