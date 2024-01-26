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
    public class TatliController : Controller
    {

        TatliManager tm = new TatliManager(new EFTatliDal());

       

   
        public ActionResult Index()
        {
            var Tatlivalues = tm.GetList();
            return View(Tatlivalues);
        }

        [HttpGet]
        public ActionResult AddTatli()
        {
         
            return View();
        }

        [HttpPost]
        public ActionResult AddTatli(Tatli p)
        {
            //cm.EFTatliService(p);
            TatliValidator TatliValidator = new TatliValidator();
            ValidationResult results = TatliValidator.Validate(p);


            if (results.IsValid)
            {
                tm.TatliAdd(p);
                return RedirectToAction("index");
            }
            else

            {
                foreach (var item in results.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }


            return View(); /*RedirectToAction("GetTatliList");*/

        }
        public ActionResult DeleteTatli(int id) //ayrı bir sayfa yapmayacagız indexte sil yapacagız.
        {
            var Tatlivalue = tm.GetByID(id);
            tm.TatliDelete(Tatlivalue);
            return RedirectToAction("index"); //indexe gönderdik
        }

        [HttpGet]
        public ActionResult EditTatli(int id)

        {
    

            var Tatlivalue = tm.GetByID(id);
            return View(Tatlivalue);
        }

        [HttpPost]
        public ActionResult EditTatli(Tatli p)
        {
            tm.TatliUpdate(p);
            return RedirectToAction("index");
        }
    }
}




