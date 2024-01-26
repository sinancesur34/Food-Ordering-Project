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
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace tekrar_100ders.Controllers
{
    public class YemekController : Controller
    {

        YemekManager ym = new YemekManager(new EFYemekDal());

       

   
        public ActionResult Index()
        {
            var Yemekvalues = ym.GetList();
            return View(Yemekvalues);
        }

        [HttpGet]
        public ActionResult AddYemek()
        {
         
            return View();
        }

        [HttpPost]
        public ActionResult AddYemek(Yemek p)
        {
            //cm.EFYemekService(p);
            YemekValidator YemekValidator = new YemekValidator();
            ValidationResult results = YemekValidator.Validate(p);


            if (results.IsValid)
            {
                ym.YemekAdd(p);
                return RedirectToAction("index");
            }
            else

            {
                foreach (var item in results.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }


            return View(); /*RedirectToAction("GetYemekList");*/

        }
        public ActionResult DeleteYemek(int id) //ayrı bir sayfa yapmayacagız indexte sil yapacagız.
        {
            var Yemekvalue = ym.GetByID(id);
            ym.YemekDelete(Yemekvalue);
            return RedirectToAction("index"); //indexe gönderdik
        }

        [HttpGet]
        public ActionResult EditYemek(int id)

        {
    

            var Yemekvalue = ym.GetByID(id);
            return View(Yemekvalue);
        }

        [HttpPost]
        public ActionResult EditYemek(Yemek p)
        {
            ym.YemekUpdate(p);
            return RedirectToAction("index");
        }
    }
}




