using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtelProject_Mvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult AnaSayfa()
        {
            return View();
        }

        public ActionResult Hakkimda()
        {
            return View();
        }

        public ActionResult Hizmetler()
        {
            return View();
        }

        public ActionResult İletisim()
        {
            return View();
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