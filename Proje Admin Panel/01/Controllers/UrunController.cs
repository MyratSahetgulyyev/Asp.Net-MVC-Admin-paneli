using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _01.Models.Entity;

namespace _01.Controllers
{
   
    public class UrunController : Controller
    {
        MvcDvStokEntities db = new MvcDvStokEntities();
        // GET: Urun
        public ActionResult Index (string p)
        {
            var degerler = from d in db.TBLURUNLER select d;
            if(!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.URUNAD.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.TBLURUNLER.ToList();
            //return View(degerler);
        }
         


        //ekleme
        [HttpPost]
        public ActionResult YeniUrun (TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORİLER.Where(m => m.KATEGORIID == p1.URUNKATEGORİ).FirstOrDefault();
            p1.TBLKATEGORİLER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return Redirect("Index");
        }


        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORİLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        //sil
        public ActionResult SIL (int id)
        {
            var urunler = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urunler);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        //veri taşı
        public ActionResult UrunGetir(int id)
        {
            var urn = db.TBLURUNLER.Find(id);
            return View(urn);
        }

        public ActionResult Guncelle(TBLURUNLER p1)
        {
            var urn = db.TBLURUNLER.Find(p1.URUNID);
            
            urn.URUNAD = p1.URUNAD;
            urn.MARKA = p1.MARKA;

            urn.URUNKATEGORİ = p1.URUNKATEGORİ;

            urn.FIYAT = p1.FIYAT;
            urn.STOK = p1.STOK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //yardım
        public ActionResult Yardim()
        {
            return View();
        }
    }
}