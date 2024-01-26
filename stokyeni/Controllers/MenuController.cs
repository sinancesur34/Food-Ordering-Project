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
    public class MenuController : Controller
    {

        MenuManager mm = new MenuManager(new EFMenuDal());

       

   
        public ActionResult Index()
        {
            var Menuvalues = mm.GetList();
            return View(Menuvalues);
        }

        [HttpGet]
        public ActionResult AddMenu()
        {
         
            return View();
        }

        [HttpPost]
        public ActionResult AddMenu(Menu p)
        {
            //cm.EFMenuService(p);
            MenuValidator MenuValidator = new MenuValidator();
            ValidationResult results = MenuValidator.Validate(p);


            if (results.IsValid)
            {
                mm.MenuAdd(p);
                return RedirectToAction("index");
            }
            else

            {
                foreach (var item in results.Errors)
                {

                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }


            return View(); /*RedirectToAction("GemmenuList");*/

        }
        public ActionResult DeleteMenu(int id) //ayrı bir sayfa yapmayacagız indexte sil yapacagız.
        {
            var Menuvalue = mm.GetByID(id);
            mm.MenuDelete(Menuvalue);
            return RedirectToAction("index"); //indexe gönderdik
        }

        [HttpGet]
        public ActionResult Editmenu(int id)

        {
    

            var Menuvalue = mm.GetByID(id);
            return View(Menuvalue);
        }

        [HttpPost]
        public ActionResult Editmenu(Menu p)
        {
            mm.MenuUpdate(p);
            return RedirectToAction("index");
        }
    }
}




