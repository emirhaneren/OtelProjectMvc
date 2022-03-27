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

        public ActionResult Hakkimda()
        {
            var veriler = db.TblHakkimda.ToList();
            return View(veriler);
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialSosyalMedya()
        {
            return PartialView();
        }
    }
}