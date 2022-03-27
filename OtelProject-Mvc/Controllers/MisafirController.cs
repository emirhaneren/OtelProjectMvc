using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelProject_Mvc.Models.Entity;

namespace OtelProject_Mvc.Controllers
{
    public class MisafirController : Controller
    {

        DbOtelEntities db = new DbOtelEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rezervasyonlarim()
        {
            //Hangi misafirin değerlerinin getiriileceği
            var degerler = db.TblRezervasyon.Where(x => x.Misafir == 1).ToList();
            return View(degerler);
        }
    }
}