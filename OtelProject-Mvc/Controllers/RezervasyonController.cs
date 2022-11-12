using OtelProject_Mvc.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OtelProject_Mvc.Controllers
{
    public class RezervasyonController : Controller
    {
        // GET: Rezervasyon
        DbOtelEntities db = new DbOtelEntities();

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblOnRezervasyon p)
        {
            var misafirMail = (string)Session["Mail"];
            // var misafirid = db.TblYeniKayit.Where(x => x.Mail == misafirMail).Select(x => x.ID).FirstOrDefault();
            //p.Durum = 3006;
            //p.Misafir = misafirid;
            p.Mail = misafirMail;
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

            db.TblOnRezervasyon.Add(p);
            db.SaveChanges();
            return RedirectToAction("Rezervasyonlarim", "Misafir");
        }
    }
}