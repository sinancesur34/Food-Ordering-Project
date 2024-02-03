using BusinessLayer.Concrete;
using BusinessLayer.ValidationRulers_fluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace tekrar_100ders.Controllers
{
    public class SatisController : Controller
    {

        SatisManager sm = new SatisManager(new EFSatisDal());

        TatliManager tm = new TatliManager(new EFTatliDal());


        YemekManager ym = new YemekManager(new EFYemekDal());

        MenuManager mm = new MenuManager(new EFMenuDal());

        SalataManager sam = new SalataManager(new EFSalataDal());



   
        public ActionResult Index()
        {
            var Satisvalues = sm.GetList();
            return View(Satisvalues);
        }


        [HttpGet]
        public ActionResult AddSatis()
        {



            List<SelectListItem> valueTatli = (from x in tm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.TatliName + "  (" + x.Fiyat + "₺)",
                                                   Value = x.TatliID.ToString()

                                               }
                                                   ).ToList();
            ViewBag.vlt = valueTatli;


            List<SelectListItem> valueYemek = (from x in ym.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.YemekName + "  (" + x.Fiyat + "₺)",
                                                   Value = x.YemekID.ToString()

                                               }
                                                ).ToList();
            ViewBag.vly = valueYemek;

            List<SelectListItem> valueMenu = (from x in mm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.MenuName + "  (" + x.Fiyat + "₺)",
                                                   Value = x.MenuID.ToString()

                                               }
                                                ).ToList();
            ViewBag.vlm = valueMenu;

            List<SelectListItem> valueSalata = (from x in sam.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.SalataName + "  (" + x.Fiyat + "₺)",
                                                   Value = x.SalataID.ToString()

                                               }
                                                ).ToList();
            ViewBag.vlsa = valueSalata;

       



            return View();
        }

       

        [HttpPost]
        public ActionResult AddSatis(Satis p)
        {
            //tm.EFIcecekService(p);
            SatisValidator SatisValidator = new SatisValidator();

            ValidationResult results = SatisValidator.Validate(p);


            if (results.IsValid)
            {
                p.Tarih = DateTime.Now;

                sm.SatisAdd(p);
                return RedirectToAction("index");
            }
            else

            {
                foreach (var item in results.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }


            return View();

        }


        [HttpPost]
        public ActionResult AddSatis(List<SiparisDetay> siparisDetaylari)
        {
            try
            {
                // siparisDetaylari'yi veritabanına kaydedin
                // Burada veritabanına kaydetme mantığınızı ekleyin

                return Json(new { success = true, message = "Sipariş başarıyla kaydedildi!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Sipariş kaydedilirken hata oluştu: " + ex.Message });
            }
        }


        public ActionResult DeleteSatis(int id) //ayrı bir sayfa yapmayacagız indexte sil yapacagız.
        {
            var Satisvalue = sm.GetByID(id);
            sm.SatisDelete(Satisvalue);
            return RedirectToAction("index"); //indexe gönderdik
        }


        //// Get Metodu, Bu metod ne işe yarar: Geriye Yemek listesini döndürecek
        //[HttpGet]
        //public List<String> YemekList()
        //{
        //    List<String> yemekler = new List<String>();  

        //    List<Yemek> yemekListesi =  ym.GetList().ToList();

        //    foreach (var yemek in yemekListesi)
        //    {
        //        //Debug.WriteLine($"Yemek ID: {yemek.YemekID}, Yemek Adı: {yemek.YemekName}, Fiyat: {yemek.Fiyat}");
        //        yemekler.Add(yemek.YemekName);
        //    }

        //    return yemekler;
        //}



        [HttpGet]
        public ActionResult DetailSatis(int id)
        {


            List<SelectListItem> GetvalueTatli = (from x in tm.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.TatliName + "  " + x.Fiyat ,
                                                   Value = x.TatliID.ToString()

                                               }
                                                   ).ToList();
            ViewBag.vlt = GetvalueTatli;


            List<SelectListItem> GetvalueYemek = (from x in ym.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.YemekName + "  " + x.Fiyat,
                                                      Value = x.YemekID.ToString()

                                               }
                                                ).ToList();
            ViewBag.vly = GetvalueYemek;

            List<SelectListItem> valueMenu = (from x in mm.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.MenuName + "  " + x.Fiyat,
                                                  Value = x.MenuID.ToString()

                                              }
                                                ).ToList();
            ViewBag.vlm = valueMenu;

            List<SelectListItem> GetEditSatis = (from x in sam.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.SalataName + "  " + x.Fiyat,
                                                    Value = x.SalataID.ToString()

                                                }
                                                ).ToList();
            ViewBag.vlsa = GetEditSatis; 

            var Satisvalue = sm.GetByID(id);
            return View(Satisvalue);
        }

        [HttpPost]
        public ActionResult DetailSatis(Satis p)
        {


            p.Tarih = DateTime.Now;


            sm.SatisUpdate(p);
            return RedirectToAction("index");
        }


        [HttpGet]
        public ActionResult EditSatis(int id)
        {


            List<SelectListItem> GetvalueTatli = (from x in tm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.TatliName + "  " + x.Fiyat,
                                                      Value = x.TatliID.ToString()

                                                  }
                                                   ).ToList();
            ViewBag.vlt = GetvalueTatli;


            List<SelectListItem> GetvalueYemek = (from x in ym.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.YemekName + "  " + x.Fiyat,
                                                      Value = x.YemekID.ToString()

                                                  }
                                                ).ToList();
            ViewBag.vly = GetvalueYemek;

            List<SelectListItem> valueMenu = (from x in mm.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.MenuName + "  " + x.Fiyat,
                                                  Value = x.MenuID.ToString()

                                              }
                                                ).ToList();
            ViewBag.vlm = valueMenu;

            List<SelectListItem> GetEditSatis = (from x in sam.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.SalataName + "  " + x.Fiyat,
                                                     Value = x.SalataID.ToString()

                                                 }
                                                ).ToList();
            ViewBag.vlsa = GetEditSatis;

            var Satisvalue = sm.GetByID(id);
            return View(Satisvalue);
        }

        [HttpPost]
        public ActionResult EditSatis(Satis p)
        {



            p.Tarih = DateTime.Now;


            sm.SatisUpdate(p);
            return RedirectToAction("index");
        }


    }
}

