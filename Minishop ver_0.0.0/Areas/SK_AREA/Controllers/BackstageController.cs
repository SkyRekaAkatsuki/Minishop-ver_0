using Minishop_ver_0._0._0.Areas.SK_AREA.Models.Interface.SupplierR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Minishop_ver_0._0._0.Areas.SK_AREA.Models;

namespace Minishop_ver_0._0._0.Areas.SK_AREA.Controllers
{
    public class BackstageController : Controller
    {
        private SupplierRepository repository = new SupplierRepository();
        // GET: SK_AREA/Backstage
        public ActionResult Index(int? page)
        {
            if (HttpContext.Request.Cookies["IsLogin"].Value == "Admin")
            {
                //記錄目前頁數,若是空值就給1
                TempData["page1"] = page ?? 1;
                return View(repository.GetAll().ToList().ToPagedList(page ?? 1,3));
            }
            else
            {
                RedirectToAction("PermissionError", "ProductMaintain");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            return View(repository.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Supplier form)
        {
            //Supplier newsupplier = new Supplier();
            //newsupplier.SupplierID = Convert.ToInt32(Request.Form["SupplierID"]);
            //newsupplier.SupplierName = Request.Form["SupplierName"];
            //newsupplier.Phone = Request.Form["Phone"];
            //newsupplier.Fax = Request.Form["Fax"];
            //newsupplier.Email = Request.Form["Email"];
            //newsupplier.Address = Request.Form["Address"];
            //newsupplier.CreateDate = Convert.ToDateTime(Request.Form["CreateDate"]);

            //repository.Update(newsupplier);

            //return RedirectToAction("Index");

            //Supplier ViewBag = new Supplier();
            //ViewBag.SupplierID = form.SupplierID;
            //ViewBag.SupplierName = form.SupplierName;
            //ViewBag.Phone = form.Phone;
            //ViewBag.Fax = form.Fax;
            //ViewBag.Email = form.Email;
            //ViewBag.Address = form.Address;
            //ViewBag.CreateDate = DateTime.Now;

            form.CreateDate = DateTime.Now;
            repository.Update(form);

            //return RedirectToAction("Index");
            return RedirectToAction("Index", "Backstage", new { area = "SK_AREA", page = TempData["page1"] });

        }

        public ActionResult Create(Supplier form)
        {
            if(Request.Form.Count > 0)
            {

                //Supplier newsupplier = new Supplier();
                //newsupplier.SupplierID = Convert.ToInt32(Request.Form["SupplierID"]);
                //newsupplier.SupplierName = Request.Form["SupplierName"];
                //newsupplier.Phone = Request.Form["Phone"];
                //newsupplier.Fax = Request.Form["Fax"];
                //newsupplier.Email = Request.Form["Email"];
                //newsupplier.Address = Request.Form["Address"];
                //newsupplier.CreateDate = Convert.ToDateTime(Request.Form["CreateDate"]);

                //repository.Creat(newsupplier);

                //return RedirectToAction("Index");

                //Supplier ViewBag = new Supplier();
                //ViewBag.SupplierID = form.SupplierID;
                //ViewBag.SupplierName = form.SupplierName;
                //ViewBag.Phone = form.Phone;
                //ViewBag.Fax = form.Fax;
                //ViewBag.Email = form.Email;
                //ViewBag.Address = form.Address;
                //ViewBag.CreateDate = DateTime.Now;
                form.CreateDate = DateTime.Now;
                repository.Create(form);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id = 0)
        {
            repository.Delete(repository.GetById(id));
            return RedirectToAction("Index");

        }
    }
}