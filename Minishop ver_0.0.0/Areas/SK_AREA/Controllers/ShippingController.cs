using Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.ShippingR;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Controllers
{

    public class ShippingController : Controller
    {
        private ShippingRepository repository = new ShippingRepository();


        // GET: SK_AREA/Shipping
        public ActionResult Index(int? page)
        {
            TempData["Page555+"] = page;
            return View(repository.GetAll().ToList().ToPagedList(page ?? 1,3));
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            return View(repository.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Shipping X)
        {
            if (ModelState.IsValid)
            {
                X.CreateDate = DateTime.Now;
                repository.Update(X);
            }
                return RedirectToAction("Index", "Shipping", new { area = "SK_AREA", page = TempData["Page555+"] });
            
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Shipping Y)
        {
            if (ModelState.IsValid)
            {
                Y.CreateDate = DateTime.Now;
                repository.Create(Y);
            }
            
            
            return RedirectToAction("Index");

        }


        public ActionResult Delete(int id=0)
        {

            repository.Delete(repository.GetById(id));
            return RedirectToAction("Index");
        }
    }
}