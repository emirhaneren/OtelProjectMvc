using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelProject_Mvc.Models.Entity;


namespace OtelProject_Mvc.Controllers
{
    public class IletisimController : Controller
    {
        DbOtelEntities db = new DbOtelEntities();
        // GET: Iletisim
        public ActionResult Index()
        {
            var bilgiler = db.Tbliletisim.ToList();
            return View(bilgiler);
        }

        [HttpGet]
        public PartialViewResult MesajGonder()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult MesajGonder(TblMesaj p)
        {
            db.TblMesaj.Add(p);
            db.SaveChanges();
            return PartialView();
        }
    }
}