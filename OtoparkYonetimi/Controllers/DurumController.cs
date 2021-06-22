using Microsoft.Ajax.Utilities;
using OtoparkYonetimi.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoparkYonetimi.Controllers
{
    //[Authorize]
    public class DurumController : Controller
    {
        OtoparkYonetimiEntities db = new OtoparkYonetimiEntities();
        // GET: Durum
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult OtoparkDurum()
        {
            List<Tbl_ParkYeri> liste = new List<Tbl_ParkYeri>();
            if (User.IsInRole("A"))
            {
                liste = db.Tbl_ParkYeri.ToList();
                return View(liste);
            }
            liste = db.Tbl_ParkYeri.ToList().Where(x => x.Durum == true).ToList();
            return View(liste);
        }

        [HttpPost]
        public ActionResult OtoparkDurum(Tbl_ParkYeri p)
        {
            db.Tbl_ParkYeri.Add(p);
            db.SaveChanges();
            return RedirectToAction("OtoparkDurum");
        }

        public ActionResult Sil(int id)
        {
            db.Tbl_ParkYeri.Remove(db.Tbl_ParkYeri.Find(id));
            db.SaveChanges();
            return RedirectToAction("OtoparkDurum");
        }

    }
}