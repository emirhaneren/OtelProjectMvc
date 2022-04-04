using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelProject_Mvc.Models.Entity;

namespace OtelProject_Mvc.Controllers
{
    public class DefaultController : Controller
    {
        //Database bağlantısı
        DbOtelEntities db = new DbOtelEntities();

        public PartialViewResult Ekibimiz()
        {
            var ekipListesi = db.TblEkibimiz.ToList();
            return PartialView(ekipListesi);
        }

        public PartialViewResult Referans()
        {
            return PartialView();
        }

        public PartialViewResult Istatistik()
        {
            return PartialView();
        }

        public ActionResult Hakkimda()
        {
            var veriler = db.TblHakkimda.ToList();
            return View(veriler);
        }

        public PartialViewResult PartialFooter()
        {
            var doluoda = db.TblOda.Where(x => x.Durum != 1).Count();
            ViewBag.d = doluoda;
            var bosoda = db.TblOda.Where(x => x.Durum == 1).Count();
            ViewBag.b = bosoda;
            return PartialView();
        }

        public PartialViewResult PartialSosyalMedya()
        {
            return PartialView();
        }
    }
}