using OtoparkYonetimi.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OtoparkYonetimi.Controllers
{
    [AllowAnonymous]
    public class KullaniciController : Controller
    {
        OtoparkYonetimiEntities db = new OtoparkYonetimiEntities();
        // GET: Kullanici
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Tbl_Kullanicilar k)
        {
            var kullanici = db.Tbl_Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == k.KullaniciAdi && x.KullaniciSifre == k.KullaniciSifre);
            if (kullanici != null)
            {
                FormsAuthentication.SetAuthCookie(k.KullaniciAdi, false);
                Session["KullaniciAdi"] = k.KullaniciAdi;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.hata = "Kullanıcı adı veya şifre hatalı";
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}