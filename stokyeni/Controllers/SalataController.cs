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
    public class SalataController : Controller
    {

        SalataManager sam = new SalataManager(new EFSalataDal());

       

   
        public ActionResult Index()
        {
            var Salatavalues = sam.GetList();
            return View(Salatavalues);
        }

        [HttpGet]
        public ActionResult AddSalata()
        {
         
            return View();
        }

        [HttpPost]
        public ActionResult AddSalata(Salata p)
        {
            //cm.EFSalataService(p);
            SalataValidator SalataValidator = new SalataValidator();
            ValidationResult results = SalataValidator.Validate(p);


            if (results.IsValid)
            {
                sam.SalataAdd(p);
                return RedirectToAction("index");
            }
            else

            {
                foreach (var item in results.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }


            return View(); /*RedirectToAction("GetSalataList");*/

        }
        public ActionResult DeleteSalata(int id) //ayrı bir sayfa yapmayacagız indexte sil yapacagız.
        {
            var Salatavalue = sam.GetByID(id);
            sam.SalataDelete(Salatavalue);
            return RedirectToAction("index"); //indexe gönderdik
        }

        [HttpGet]
        public ActionResult EditSalata(int id)

        {
    

            var Salatavalue = sam.GetByID(id);
            return View(Salatavalue);
        }

        [HttpPost]
        public ActionResult EditSalata(Salata p)
        {
            sam.SalataUpdate(p);
            return RedirectToAction("index");
        }
    }
}




