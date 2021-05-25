using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _01.Models.Entity;
using PagedList;
using PagedList.Mvc;


namespace _01.Controllers
{
    public class MusteriController : Controller
    {
        MvcDvStokEntities db = new MvcDvStokEntities();
        // GET: Musteri
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TBLMUSTERI.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }


        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERI p1)
        {
            db.TBLMUSTERI.Add(p1);
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        //sil
         
        public ActionResult SIL (int id)
        {
            var musteri = db.TBLMUSTERI.Find(id);
            db.TBLMUSTERI.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //veri taşı
        public ActionResult MusteriGetir(int id)
        {
            var mstr = db.TBLMUSTERI.Find(id);
            return View(mstr);
        }

        //Güncelle
        public ActionResult Guncelle(TBLMUSTERI p1)
        {
            var mst = db.TBLMUSTERI.Find(p1.MUSTERIID);
            mst.MUSTERIAD = p1.MUSTERIAD;
            mst.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //bhghg
    }
}