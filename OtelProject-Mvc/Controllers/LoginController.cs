using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OtelProject_Mvc.Models.Entity;

namespace OtelProject_Mvc.Controllers
{
    public class LoginController : Controller
    {

        DbOtelEntities db = new DbOtelEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblYeniKayit p)
        {
            //Giris Yaparken mail ve sifreyi dogrulama
            var bilgiler = db.TblYeniKayit.FirstOrDefault(x => x.Mail == p.Mail && x.Sifre==p.Sifre);
            if(bilgiler!=null)
            {
                //cookkie ile oturum bilgilerini tutma
                FormsAuthentication.SetAuthCookie(bilgiler.Mail,false);
               //Maile parametresi ile oturumda kalma
                Session["Mail"] = bilgiler.Mail.ToString();
                return RedirectToAction("Index","Misafir");
            }
            else
            {
                return RedirectToAction("Index");
            }

            return View();
        }

    }

}