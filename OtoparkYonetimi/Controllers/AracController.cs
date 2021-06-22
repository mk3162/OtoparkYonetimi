using OtoparkYonetimi.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoparkYonetimi.Controllers
{
    //[Authorize(Roles ="A,P")]
    public class AracController : Controller
    {
        OtoparkYonetimiEntities db = new OtoparkYonetimiEntities();
        // GET: Arac
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "A,P")]
        public ActionResult AracGoster() 
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles ="A,P")]
        public ActionResult AracGoster(Tbl_Araclar a)
        {
            db.Tbl_Araclar.Add(a);
            db.SaveChanges();
            return RedirectToAction("AracCikis");
        }
        public ActionResult AracCikis()
        {
            var list = db.Tbl_Araclar.ToList();
            return View(list);
        }
        public ActionResult Sil(int id)
        {
            db.Tbl_Araclar.Remove(db.Tbl_Araclar.Find(id));
            db.SaveChanges();
            return RedirectToAction("AracCikis");
        }
        public ActionResult AracGetir(int id)
        {
            var arac = db.Tbl_Araclar.Find(id);
            return View("AracGetir", arac);
        }
        public ActionResult AracGuncelle(Tbl_Araclar a)
        {
            var kisi = db.Tbl_Araclar.Find(a.AracId);
            kisi.AracId = a.AracId;
            kisi.AracPlaka = a.AracPlaka;
            kisi.AracMarka = a.AracMarka;
            kisi.AracRenk = a.AracRenk;
            kisi.KisiId = a.KisiId;
            db.SaveChanges();
            return RedirectToAction("AracCikis");
        }
    }
}