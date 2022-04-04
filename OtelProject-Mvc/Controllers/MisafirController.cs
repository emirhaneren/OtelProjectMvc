using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OtelProject_Mvc.Models.Entity;

namespace OtelProject_Mvc.Controllers
{
    //Giriş Yapılmadan panele yönlendirme olmaması için controller seviseyine taşınır
    //Web config üzerinden loginurl'e yönlendirmenin yapılacak olduğu konum yazılır
    [Authorize]

    public class MisafirController : Controller
    {
        
        DbOtelEntities db = new DbOtelEntities();

        public ActionResult Index()
        {
            var misafirMail = (string)Session["Mail"];
            var misafirBilgi = db.TblYeniKayit.Where(x => x.Mail == misafirMail).FirstOrDefault();
            return View(misafirBilgi);
        }

        public ActionResult Rezervasyonlarim()
        {
            //Oturumdaki kullanıcının mail adresini alma
            var misafirMail = (string)Session["Mail"];
            //ViewBag.a = misafirMail;
            
            var misafirId = db.TblYeniKayit.Where(x => x.Mail == misafirMail).Select(y => y.ID).FirstOrDefault();
            
            //Hangi misafirin değerlerinin getiriileceği
            var degerler = db.TblRezervasyon.Where(x => x.Misafir == misafirId).ToList();
            return View(degerler);
        }

        public ActionResult MisafirBilgiGuncelle(TblYeniKayit p)
        {
            var misafir = db.TblYeniKayit.Find(p.ID);
            misafir.AdSoyad = p.AdSoyad;
            misafir.Sifre = p.Sifre;
            misafir.Telefon = p.Telefon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","AnaSayfa");  
        }

        public ActionResult GelenMesajlar()
        {
            var misafirMail = (string)Session["Mail"];
            var mesajlar = db.TblMesaj2.Where(x => x.Alici ==misafirMail).ToList();
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var misafirMail = (string)Session["Mail"];
            var mesajlar = db.TblMesaj2.Where(x => x.Gonderen == misafirMail).ToList();
            return View(mesajlar);
        }

        public ActionResult MesajDetay(int id)
        {
            var mesaj = db.TblMesaj2.Where(x => x.MesajID == id).FirstOrDefault();
            return View(mesaj);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(TblMesaj2 p)
        {
            var misafirMail = (string)Session["Mail"];
            p.Gonderen = misafirMail;
            p.Alici = "Admin";
            p.Tarih = DateTime.Parse(DateTime.Now.ToLongTimeString());
            db.TblMesaj2.Add(p);
            db.SaveChanges();
            return RedirectToAction("GidenMesajlar", "Misafir");
        }

    }
}