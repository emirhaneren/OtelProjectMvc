﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtelProject_Mvc.Models.Entity;

namespace OtelProject_Mvc.Controllers
{
    public class KayitController : Controller
    {
        // GET: Kayit

        DbOtelEntities db = new DbOtelEntities();

        //HttpGet sayfa yüklendiğinde çalışır
        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }

        //HttpPost form tetiklendiğinde çalışır
        [HttpPost]
        public ActionResult KayitOl(TblYeniKayit p)
        {
            db.TblYeniKayit.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}