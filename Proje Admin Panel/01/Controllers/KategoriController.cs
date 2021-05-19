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
    public class KategoriController : Controller
    {
        // GET: Kategori
        //bağlan
        MvcDvStokEntities db = new MvcDvStokEntities();


        //listele PagedList ile
        public ActionResult Index( int sayfa=1)
        {
            //var degerler = db.TBLKATEGORİLER.ToList();
            var degerler = db.TBLKATEGORİLER.ToList().ToPagedList(sayfa, 4);
            return View(degerler);
        }




        //ekle
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORİLER p1)
        {
            db.TBLKATEGORİLER.Add(p1);
            db.SaveChanges();
            return View();
        }

        //Sil

        public ActionResult SIL (int id)
        {
            var kategori = db.TBLKATEGORİLER.Find(id);
            db.TBLKATEGORİLER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //veri taşı

        public ActionResult KategoriGetir (int id)
        {
            var ktgr = db.TBLKATEGORİLER.Find(id);
            return View("KategoriGetir", ktgr);
        }

        //Güncelle
        public ActionResult Guncelle (TBLKATEGORİLER p1)
        {
            var ktg = db.TBLKATEGORİLER.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}